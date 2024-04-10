using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyType : MonoBehaviour
{
    public EnemyController controller;

    // �߰�
    public abstract void ChaseEnter();
    public abstract void ChaseUpdate();
    public abstract void ChaseFixedUpdate();
    public abstract void ChaseExit();

    // ����
    public abstract void AttackEnter();
    public abstract void AttackUpdate();
    public abstract void AttackFixedUpdate();
    public abstract void AttackExit();

    // ����
    public abstract void StiffenEnter();
    public abstract void StiffenUpdate();
    public abstract void StiffenFixedUpdate();
    public abstract void StiffenExit();

    // ����
    public abstract void DeadEnter();
    public abstract void DeadUpdate();
    public abstract void DeadFixedUpdate();
    public abstract void DeadExit();
}
