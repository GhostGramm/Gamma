using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    #region Components
    public Animator p_Anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region PlayerStates
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    #endregion

    #region Values
    [Header("Variables")]
    public float moveSpeed = 5;
    public float dashSpeed = 15;
    public float jumpForce = 10;
    public float facingDirection = 1;
    public bool facingRight = true;
    #endregion

    #region Collision Checks
    [Header("Collisions Checks")]
    [SerializeField] private Transform GroundPoint;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;
    [Space]
    [SerializeField] private Transform WallPoint;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private LayerMask WhatIsWall;
    #endregion

    #region Timers
    [Header("Dash Info")]
    public float dashTimer;
    public float dashReset;
    public float dashingTime;
    public float dashDirection;
    #endregion

    private void Awake()
    {

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        airState  = new PlayerAirState(this, stateMachine,  "jump");
        dashState = new PlayerDashState(this, stateMachine, "dash");
    }

    private void Start()
    {
        GetInitialComponent();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
        CheckForDash();
    }
    
    private void GetInitialComponent()
    {
        p_Anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }

    public void CheckForDash()
    {
        dashingTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashingTime > 0) return;
            dashDirection = Input.GetAxis("Horizontal");

            if (dashDirection == 0) dashDirection = facingDirection;

            stateMachine.ChangeState(dashState);
            dashingTime = dashReset;
        }
    }

    public void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x)
    {
        if(x > 0 && !facingRight)   Flip();
        else if(x < 0 && facingRight) Flip();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundPoint.position, new Vector3(GroundPoint.position.x, GroundPoint.position.y - GroundCheckDistance));
        Gizmos.DrawLine(WallPoint.position, new Vector3(WallPoint.position.x + WallCheckDistance, WallPoint.position.y));
    }

    public bool isGrounded() => Physics2D.Raycast(GroundPoint.position, Vector2.down, GroundCheckDistance, WhatIsGround);
    public bool isWallDetected() => Physics2D.Raycast(WallPoint.position, Vector2.right, WallCheckDistance, WhatIsWall);

}
