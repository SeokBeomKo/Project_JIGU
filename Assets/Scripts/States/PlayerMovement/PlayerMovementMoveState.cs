using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveState : CharacterState
{
    public CharacterMoveState(UserCharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.animator.Play("MOVE");
    }
    public override void Update()
    {

    }
    public override void FixedUpdate()
    {
        controller.Move();
    }
    public override void Exit()
    {
        
    }
}
