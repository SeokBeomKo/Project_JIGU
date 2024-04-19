using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState : IState
{
    protected UserCharacterController controller;
    protected CharacterMovementFSM stateMachine;

    public CharacterState(UserCharacterController controller)
    {
        this.controller = controller;
        this.stateMachine = controller.movementFSM;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();
}
