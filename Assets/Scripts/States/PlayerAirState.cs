using System.Collections;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public float airMovementVelocity = 0.8f;
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
    { 
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0) player.SetVelocity(player.moveSpeed * xInput * airMovementVelocity, rb.velocity.y);
        if (player.isWallDetected() && rb.velocity.y < 0) stateMachine.ChangeState(player.wallSlideState);
        if (player.isGrounded()) stateMachine.ChangeState(player.idleState);
    }
}