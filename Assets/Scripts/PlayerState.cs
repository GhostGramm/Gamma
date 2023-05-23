using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBool;
    protected float xInput = 0;
    protected Rigidbody2D rb;

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
        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit()
    {
        player.p_Anim.SetBool(animBool, false);
    }
}
