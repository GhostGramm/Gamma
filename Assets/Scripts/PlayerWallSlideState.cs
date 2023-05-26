using System.Collections;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Wall Slide started");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Wall state ended");
    }

    public override void Update()
    {
        base.Update();

        if ((xInput != 0) && (player.facingDirection != xInput)) stateMachine.ChangeState(player.idleState);

        if (player.isGrounded()) stateMachine.ChangeState(player.idleState);

        if(yInput == 0)
        {
            player.SetVelocity(0, rb.velocity.y * 0.5f);
        }
        else
        {
            player.SetVelocity(rb.velocity.x, rb.velocity.y);
        }
    }
}