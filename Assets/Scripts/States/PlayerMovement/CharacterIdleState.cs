using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterState
{
    public CharacterIdleState(BaseCharacterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        controller.animator.Play("IDLE");
        controller.rigid.velocity = Vector2.zero;
    }
    public override void Update()
    {

    }
    public override void FixedUpdate()
    {

    }
    public override void Exit()
    {
        
    }
}
