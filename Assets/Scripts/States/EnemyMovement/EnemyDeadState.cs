using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(EnemyController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.enemyType.DeadEnter();
    }

    public override void Update()
    {
        controller.enemyType.DeadUpdate();
    }

    public override void FixedUpdate()
    {
        controller.enemyType.DeadFixedUpdate();
    }

    public override void Exit()
    {
        controller.enemyType.DeadExit();
    }
}