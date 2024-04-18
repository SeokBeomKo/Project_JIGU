using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPreparationState : EnemyState
{
    public EnemyAttackPreparationState(EnemyController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.enemyType.AttackPreparationEnter();
    }

    public override void Update()
    {
        controller.enemyType.AttackPreparationUpdate();
    }

    public override void FixedUpdate()
    {
        controller.enemyType.AttackPreparationFixedUpdate();
    }

    public override void Exit()
    {
        controller.enemyType.AttackPreparationExit();
    }
}
