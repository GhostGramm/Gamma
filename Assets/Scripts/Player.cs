using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    #endregion

    #region Values
    [Header("Variables")]
    public float moveSpeed = 5;
    #endregion

    private void Awake()
    {

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");

    }

    private void Start()
    {
        GetInitialComponent();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
    
    private void GetInitialComponent()
    {
        p_Anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }

}
