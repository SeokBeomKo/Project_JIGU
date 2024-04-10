using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : IState
{
    protected EnemyController controller;
    protected EnemyMovementFSM stateMachine;

    public EnemyState(EnemyController controller)
    {
        this.controller = controller;
        this.stateMachine = controller.movementFSM;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();
}
