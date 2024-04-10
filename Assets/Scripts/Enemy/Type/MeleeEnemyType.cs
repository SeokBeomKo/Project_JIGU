using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyType : EnemyType
{
    bool isLive = true;
    public float chaseSpeed;

    // �߰�
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
        if (!isLive) return; // ���߿� �ݶ��̴� ��������

        Vector2 directionVector = controller.target.position - controller.rigid.position;
        Vector2 nextVector = directionVector.normalized * chaseSpeed * Time.fixedDeltaTime;

        controller.rigid.MovePosition(controller.rigid.position + nextVector);
        controller.rigid.velocity = Vector2.zero; // ���� �ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ���� 
    }
    public override void ChaseExit()
    {

    }

    // ����
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
