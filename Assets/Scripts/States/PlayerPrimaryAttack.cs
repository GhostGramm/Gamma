using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerPrimaryAttack : PlayerState
{
    public PlayerPrimaryAttack(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
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
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if (isTriggerCalled) stateMachine.ChangeState(player.idleState);
    }
}
