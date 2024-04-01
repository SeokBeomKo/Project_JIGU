using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIdleState : PlayerState
{
    public PlayerMovementIdleState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
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
