using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : IState
{
    protected PlayerController controller;
    protected PlayerMovementFSM stateMachine;

    public PlayerState(PlayerController controller)
    {
        this.controller = controller;
        this.stateMachine = controller.movementFSM;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();
}
