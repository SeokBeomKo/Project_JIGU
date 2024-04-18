using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyType : MonoBehaviour
{
    public EnemyController controller;

    // 추격
    public abstract void ChaseEnter();
    public abstract void ChaseUpdate();
    public abstract void ChaseFixedUpdate();
    public abstract void ChaseExit();

    // 공격 준비 
    public abstract void AttackPreparationEnter();
    public abstract void AttackPreparationUpdate();
    public abstract void AttackPreparationFixedUpdate();
    public abstract void AttackPreparationExit();

    // 공격
    public abstract void AttackEnter();
    public abstract void AttackUpdate();
    public abstract void AttackFixedUpdate();
    public abstract void AttackExit();

    // 경직
    public abstract void StiffenEnter();
    public abstract void StiffenUpdate();
    public abstract void StiffenFixedUpdate();
    public abstract void StiffenExit();

    // 죽음
    public abstract void DeadEnter();
    public abstract void DeadUpdate();
    public abstract void DeadFixedUpdate();
    public abstract void DeadExit();

    // 그 외 함수
    public void FlipSprite()
    {
        controller.spriteRenderer.flipX = controller.target.position.x < controller.rigid.position.x;
    }

    public void FlipWeapon(GameObject weapon, bool isflip = true)
    {
        SpriteRenderer weaponSpriteRenderer = weapon.GetComponent<SpriteRenderer>();
        weaponSpriteRenderer.flipX = controller.spriteRenderer.flipX && isflip;
    }

    public float CalculateDistance()
    {
        float range = Vector2.Distance(controller.rigid.position, controller.target.position);
        return range;
    }

    public IEnumerator AttackDelay(float second, EnemyStateEnums state)
    {
        yield return new WaitForSeconds(second);
        // Debug.Log(second + "초 지남");
        controller.movementFSM.ChangeState(state);
    }

    public void ChaseTarget(float chaseSpeed)
    {
        Vector2 directionVector = controller.target.position - controller.rigid.position;
        Vector2 nextVector = directionVector.normalized * chaseSpeed * Time.fixedDeltaTime;

        controller.rigid.MovePosition(controller.rigid.position + nextVector);
        controller.rigid.velocity = Vector2.zero;  // 물리 속도가 이동에 영향을 주지 않도록 속도 제거 
    }

}
