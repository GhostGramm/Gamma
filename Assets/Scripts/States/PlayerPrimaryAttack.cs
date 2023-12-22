using System.Security.Cryptography;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lastAttackTime;
    private int comboWindow = 2;

    //const
    private const string ANIMATIONPARAMETER = "comboCounter";

    public PlayerPrimaryAttack(Player player, PlayerStateMachine stateMachine, string animBool) : base(player, stateMachine, animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 0.1f;

        if (comboCounter > 2 || Time.time > lastAttackTime + comboWindow)
        {
            comboCounter = 0;
        }

        player.SetVelocity(xInput, rb.velocity.y);

        player.p_Anim.SetInteger(ANIMATIONPARAMETER, comboCounter);
    }

    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        
        lastAttackTime = Time.time;

        player.StartCoroutine("BusyFor", .1f);
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0)
        {
            player.SetVelocity(0, 0);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if (isTriggerCalled) stateMachine.ChangeState(player.idleState);
    }
}
