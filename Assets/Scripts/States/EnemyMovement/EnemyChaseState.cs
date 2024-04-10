using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(EnemyController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.enemyType.ChaseEnter();
    }

    public override void Update()
    {
        controller.enemyType.ChaseUpdate();
    }

    public override void FixedUpdate()
    {
        controller.enemyType.ChaseFixedUpdate();
    }

    public override void Exit()
    {
        controller.enemyType.ChaseExit();
    }
}