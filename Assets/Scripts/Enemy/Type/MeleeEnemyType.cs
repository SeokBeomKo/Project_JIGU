using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyType : EnemyType
{
    [Header("이동 속도")]
    public float chaseSpeed;

    [Header("사정 거리")]
    public float shootingRange;

    /*[Header("공격 준비 시간")]
    public float attackDelayTime;*/

    // 추격
    public override void ChaseEnter()
    {
        controller.animator.Play("Chase");
    }
    public override void ChaseUpdate()
    {
        FlipSprite();
    }
    public override void ChaseFixedUpdate()
    {
        ChaseTarget(chaseSpeed);

        if (CalculateDistance() <= shootingRange)
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACK);
    }
    public override void ChaseExit()
    {

    }

    // 공격 준비
    public override void AttackPreparationEnter()
    {
    }
    public override void AttackPreparationUpdate()
    {
    }
    public override void AttackPreparationFixedUpdate()
    {
    }
    public override void AttackPreparationExit()
    {

    }

    // 공격
    public override void AttackEnter()
    {
        controller.animator.Play("Attack");
    }
    public override void AttackUpdate()
    {
        FlipSprite();
    }
    public override void AttackFixedUpdate()
    {
        if (CalculateDistance() > shootingRange)
            controller.movementFSM.ChangeState(EnemyStateEnums.CHASE);
    }
    public override void AttackExit()
    {

    }

    // 경직
    public override void StiffenEnter()
    {

    }
    public override void StiffenUpdate()
    {

    }
    public override void StiffenFixedUpdate()
    {

    }
    public override void StiffenExit()
    {

    }

    // 죽음
    public override void DeadEnter()
    {

    }
    public override void DeadUpdate()
    {

    }
    public override void DeadFixedUpdate()
    {

    }
    public override void DeadExit()
    {

    }
}
