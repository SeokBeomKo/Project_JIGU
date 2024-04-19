using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState : IState
{
    protected BaseCharacterController controller;
    protected CharacterMovementFSM stateMachine;

    public CharacterState(BaseCharacterController controller)
    {
        this.controller = controller;
        this.stateMachine = controller.characterFSM;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();
}
