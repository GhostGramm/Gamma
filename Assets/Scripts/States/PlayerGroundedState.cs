using System.Collections;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
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

        //if (player.facingDirection == xInput && player.isWallDetected()) stateMachine.ChangeState(player.idleState);
        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded()) stateMachine.ChangeState(player.jumpState);

        if (Input.GetKeyDown(KeyCode.Mouse0)) stateMachine.ChangeState(player.primaryAttack);
    }
}