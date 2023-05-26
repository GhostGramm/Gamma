using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBool;
    protected float xInput = 0;
    protected float yInput = 0;
    protected Rigidbody2D rb;
    protected float stateTimer = 0;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBool)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBool = animBool;
    }

    public virtual void Enter()
    {
        rb = player.rb;
        player.p_Anim.SetBool(animBool, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.p_Anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void Exit()
    {
        player.p_Anim.SetBool(animBool, false);
    }
}
