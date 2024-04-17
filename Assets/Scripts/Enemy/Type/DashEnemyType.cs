using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemyType : EnemyType
{
    [Header("이동 속도")]
    public float chaseSpeed;

    [Header("사정 거리")]
    public float shootingRange;

    [Header("공격 준비 시간")]
    public float attackDelayTime;

    [Header("돌진 속도")]
    public float dashSpeed;
    private Vector2 dashDirection;

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
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACKPREPARATION);
    }
    public override void ChaseExit()
    {

    }

    // 공격 준비
    public override void AttackPreparationEnter()
    {
        controller.animator.Play("AttackPreparation");
        StartCoroutine(AttackDelay(attackDelayTime, EnemyStateEnums.ATTACK));
    }
    public override void AttackPreparationUpdate()
    {
    }
    public override void AttackPreparationFixedUpdate()
    {
        
    }
    public override void AttackPreparationExit()
    {
        dashDirection = controller.target.position - controller.rigid.position;
    }

    // 공격
    public override void AttackEnter()
    {
        controller.animator.Play("Dash");
    }
    public override void AttackUpdate()
    {
        controller.rigid.velocity = dashDirection.normalized * dashSpeed;
    }
    public override void AttackFixedUpdate()
    {
        FlipSprite();

        if(controller.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.99f) return;

        if (CalculateDistance() > shootingRange)
        {
            controller.movementFSM.ChangeState(EnemyStateEnums.CHASE);
        }
        else
        {
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACKPREPARATION);
        }
    }
    public override void AttackExit()
    {
        controller.rigid.velocity = Vector2.zero;
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
