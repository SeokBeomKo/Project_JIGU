using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    public PlayerMoveInputHandler handler;
    public PlayerController controller;

    private void Awake() 
    {
        handler.onIdleInput += Idle;
        handler.onMoveInput += Move;
    }

    public void Idle(Vector2 dir)
    {
        controller.movementFSM.ChangeState(PlayerMovementStateEnums.IDLE);
    }

    public void Move(Vector2 dir)
    {
        controller.moveDirection = dir;

        controller.movementFSM.ChangeState(PlayerMovementStateEnums.MOVE);
    }
}
