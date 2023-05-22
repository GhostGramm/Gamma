using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBool;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBool)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBool = animBool;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
