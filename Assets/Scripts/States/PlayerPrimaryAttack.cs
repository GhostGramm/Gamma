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

        

        if (comboCounter > 2 || Time.time > lastAttackTime + comboWindow)
        {
            comboCounter = 0;
        }

        player.p_Anim.SetInteger(ANIMATIONPARAMETER, comboCounter);
        Debug.Log(comboCounter);
    }

    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        
        lastAttackTime = Time.time;
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput, rb.velocity.y);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if (isTriggerCalled) stateMachine.ChangeState(player.idleState);
    }
}
