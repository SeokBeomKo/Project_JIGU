using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMoveState : PlayerState
{
    public PlayerMovementMoveState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {

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
