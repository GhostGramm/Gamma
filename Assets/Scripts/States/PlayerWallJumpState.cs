using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UnityEngine.Debug.Log("WallJumpState started");
        stateTimer = 1f;
        player.SetVelocity(5 * -player.facingDirection, player.jumpForce);
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log("WallJumpState ended");
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0) stateMachine.ChangeState(player.airState);
    }
}
