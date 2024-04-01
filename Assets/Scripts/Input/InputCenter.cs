using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    public PlayerMoveInputHandler handler;
    public PlayerController controller;

    private void Awake() 
    {
        handler.onMoveInput += Move;
    }

    public void Move(Vector2 dir)
    {
        Debug.Log(dir);
        controller.moveDirection = dir;

        if (dir == Vector2.zero)
            controller.movementFSM.ChangeState(PlayerMovementStateEnums.IDLE);
        else
            controller.movementFSM.ChangeState(PlayerMovementStateEnums.MOVE);
    }
}
