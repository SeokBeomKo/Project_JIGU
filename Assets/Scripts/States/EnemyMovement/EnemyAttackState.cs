using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.enemyType.AttackEnter();
    }

    public override void Update()
    {
        controller.enemyType.AttackUpdate();
    }

    public override void FixedUpdate()
    {
        controller.enemyType.AttackFixedUpdate();
    }

    public override void Exit()
    {
        controller.enemyType.AttackExit();
    }
}
