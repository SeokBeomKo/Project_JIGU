using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyType : EnemyType
{
    bool isLive = true;
    public float chaseSpeed;

    // 추격
    public override void ChaseEnter()
    {
        controller.animator.Play("Chase");
    }
    public override void ChaseUpdate()
    {
        if (!isLive) return;

        controller.spriteRenderer.flipX = controller.target.position.x < controller.rigid.position.x;
    }
    public override void ChaseFixedUpdate()
    {
        if (!isLive) return; // 나중에 콜라이더 꺼버리기

        Vector2 directionVector = controller.target.position - controller.rigid.position;
        Vector2 nextVector = directionVector.normalized * chaseSpeed * Time.fixedDeltaTime;

        controller.rigid.MovePosition(controller.rigid.position + nextVector);
        controller.rigid.velocity = Vector2.zero; // 물리 속도가 이동에 영향을 주지 않도록 속도 제거 
    }
    public override void ChaseExit()
    {

    }

    // 공격
    public override void AttackEnter()
    {

    }
    public override void AttackUpdate()
    {

    }
    public override void AttackFixedUpdate()
    {

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
