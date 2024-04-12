using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyType : EnemyType
{
    public float chaseSpeed;
    public float shootingRange;

    // �߰�
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
        Vector2 directionVector = controller.target.position - controller.rigid.position;
        Vector2 nextVector = directionVector.normalized * chaseSpeed * Time.fixedDeltaTime;

        controller.rigid.MovePosition(controller.rigid.position + nextVector);
        controller.rigid.velocity = Vector2.zero; // ���� �ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ���� 

        if (CalculateDistance() <= shootingRange)
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACK);
    }
    public override void ChaseExit()
    {

    }

    // ���� �غ�
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

    // ����
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

    // ����
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

    // ����
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
