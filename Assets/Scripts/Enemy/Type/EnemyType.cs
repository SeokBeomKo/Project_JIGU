using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyType : MonoBehaviour
{
    // 추격
    public abstract void ChaseEnter();
    public abstract void ChaseUpdate();
    public abstract void ChaseFixedUpdate();
    public abstract void ChaseExit();

    // 공격
    public abstract void AttackEnter();
    public abstract void AttackUpdate();
    public abstract void AttackFixedUpdate();
    public abstract void AttackExit();

    // 경직
    public abstract void StiffenEnter();
    public abstract void StiffenChaseUpdate();
    public abstract void StiffenChaseFixedUpdate();
    public abstract void StiffenChaseExit();

    // 죽음
    public abstract void DeadEnter();
    public abstract void DeadUpdate();
    public abstract void DeadFixedUpdate();
    public abstract void DeadExit();
}
