using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : IState
{
    protected EnemyController controller;
    protected EnemyMovementFSM stateMachine;

    public EnemyState(EnemyController controller)  // 생성자 : 스크립트가 생성될 때 자동 호출
    {
        this.controller = controller;
        this.stateMachine = controller.movementFSM;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
}
