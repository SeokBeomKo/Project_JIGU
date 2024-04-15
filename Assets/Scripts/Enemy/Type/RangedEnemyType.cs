using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyType : EnemyType
{
    [Header("몬스터 이동 속도")]
    public float chaseSpeed;

    [Header("사정 거리")]
    public float shootingRange;

    [Header("무기")]
    public GameObject weaponBow;
    public Animator weaponAnimator;

    /*[Header("활")]
    public GameObject arrow;*/

    // 추격
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
        controller.rigid.velocity = Vector2.zero; // 물리 속도가 이동에 영향을 주지 않도록 속도 제거 

        if (CalculateDistance() <= shootingRange)
            controller.movementFSM.ChangeState(EnemyStateEnums.ATTACKPREPARATION);
    }

    public override void ChaseExit()
    {

    }

    // 공격 준비
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

    // 공격
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
