using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyType : EnemyType
{
    [Header("���� �̵� �ӵ�")]
    public float chaseSpeed;

    [Header("���� �Ÿ�")]
    public float shootingRange;

    [Header("����")]
    public GameObject weaponBow;
    public Animator weaponAnimator;

    /*[Header("Ȱ")]
    public GameObject arrow;*/

    // �߰�
    public override void ChaseEnter()
    {
        controller.animator.Play("Chase");
    }
    public override void ChaseUpdate()
    {
        FlipSprite();
        FlipWeapon(weaponBow);
    }
    public override void ChaseFixedUpdate()
    {
        Vector2 directionVector = controller.target.position - controller.rigid.position;
        Vector2 nextVector = directionVector.normalized * chaseSpeed * Time.fixedDeltaTime;

        controller.rigid.MovePosition(controller.rigid.position + nextVector);
        controller.rigid.velocity = Vector2.zero; // ���� �ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ���� 

        if (CalculateDistance() <= shootingRange)
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACKPREPARATION);
    }

    public override void ChaseExit()
    {

    }

    // ���� �غ�
    public override void AttackPreparationEnter()
    {
        // weaponAnimator.Play("BowAttack");
        FlipWeapon(weaponBow, false);
    }
    public override void AttackPreparationUpdate()
    {
        FlipSprite();
    }
    public override void AttackPreparationFixedUpdate()
    {
        Vector2 currentPos = weaponBow.transform.position;
        Vector2 directionToTarget = controller.target.position - currentPos;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        weaponBow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
        FlipWeapon(weaponBow);
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
