
public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!player.isGrounded()) stateMachine.ChangeState(player.airState);
        if (xInput != 0 && !player.isBusy) stateMachine.ChangeState(player.moveState);
    }
}
