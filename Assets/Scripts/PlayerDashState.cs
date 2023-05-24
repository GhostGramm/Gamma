using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashTimer;
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashDirection * player.dashSpeed, 0);

        if (stateTimer < 0) stateMachine.ChangeState(player.idleState);
    }
}