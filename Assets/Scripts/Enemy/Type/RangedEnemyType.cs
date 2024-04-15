using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyType : EnemyType
{
    [Header("���� �̵� �ӵ�")]
    public float chaseSpeed;

    [Header("���� �غ� �ð�")]
    public float attackDelayTime;

    [Header("���� �Ÿ�")]
    public float shootingRange;

    [Header("����")]
    public GameObject weaponBow;
    public Animator weaponAnimator;
    public Vector2 directionToTarget;

    [Header("Ȱ")]
    public GameObject arrowPrefab;
    public Transform shootingPoint;
    public EnemyProjectile projectile;

    // �߰�
    public override void ChaseEnter()
    {
        controller.animator.Play("Chase");
        weaponBow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
        FlipWeapon(weaponBow, false);
        StartCoroutine(AttackDelay(attackDelayTime, EnemyStateEnums.ATTACK));
        controller.animator.Play("Attack");
    }
    public override void AttackPreparationUpdate()
    {
        FlipSprite();
    }
    public override void AttackPreparationFixedUpdate()
    {
        Vector2 currentPos = weaponBow.transform.position;
        directionToTarget = controller.target.position - currentPos;

        float weaponAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        weaponBow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, weaponAngle));
    }
    public override void AttackPreparationExit()
    {
        projectile.SetDirection(directionToTarget);
        projectile.SetAngle(weaponBow.transform.rotation);
    }

    // ����
    public override void AttackEnter()
    {
        weaponAnimator.Play("BowAttack");
        GameObject arrow = Instantiate<GameObject>(arrowPrefab);
        arrow.transform.position = shootingPoint.position;
        
    }
    public override void AttackUpdate()
    {
        FlipSprite();

        if (weaponAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.99f) return;
        
        if (CalculateDistance() > shootingRange)
        {
            controller.movementFSM.ChangeState(EnemyStateEnums.CHASE);
        }
        else
        {
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACKPREPARATION);
        }
    }
    public override void AttackFixedUpdate()
    {
    }
    public override void AttackExit()
    {
        weaponAnimator.Play("BowIdle");
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
