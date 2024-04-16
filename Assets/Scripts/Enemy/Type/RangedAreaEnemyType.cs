using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAreaEnemyType : EnemyType
{
    [Header("�̵� �ӵ�")]
    public float chaseSpeed;

    [Header("���� �Ÿ�")]
    public float shootingRange;

    [Header("���� �غ� �ð�")]
    public float attackDelayTime;

    [Header("��� �ڽ�")]
    public GameObject warningBox;
    private GameObject box;

    [Header("����")]
    public GameObject explosion;

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
        controller.rigid.velocity = Vector2.zero;

        if (CalculateDistance() <= shootingRange)
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACKPREPARATION);
    }
    public override void ChaseExit()
    {

    }

    // ���� �غ�
    public override void AttackPreparationEnter()
    {
        controller.animator.Play("Attack");

        box = Instantiate<GameObject>(warningBox);
        box.transform.position = controller.target.position;
 
        StartCoroutine(AttackDelay(attackDelayTime, EnemyStateEnums.ATTACK));
    }
    public override void AttackPreparationUpdate()
    {
        FlipSprite();
    }
    public override void AttackPreparationFixedUpdate()
    {
    }
    public override void AttackPreparationExit()
    {
        Destroy(box);
    }

    // ����
    public override void AttackEnter()
    {
        GameObject fire = Instantiate<GameObject>(explosion);
        fire.transform.position = box.transform.position;
    }
    public override void AttackUpdate()
    {
        FlipSprite();
    }
    public override void AttackFixedUpdate()
    {
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
