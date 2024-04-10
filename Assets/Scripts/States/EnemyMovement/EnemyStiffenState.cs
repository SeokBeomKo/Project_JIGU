using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStiffenState : EnemyState
{
    public EnemyStiffenState(EnemyController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.enemyType.StiffenEnter();
    }

    public override void Update()
    {
        controller.enemyType.StiffenUpdate();
    }

    public override void FixedUpdate()
    {
        controller.enemyType.StiffenFixedUpdate();
    }

    public override void Exit()
    {
        controller.enemyType.StiffenExit();
    }
}