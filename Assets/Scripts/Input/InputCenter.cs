using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    public CharacterMovementInputHandler handler;
    public UserCharacterController controller;

    private void Awake() 
    {
        handler.onIdleInput += Idle;
        handler.onMoveInput += Move;
    }

    public void Idle(Vector2 dir)
    {
        controller.characterFSM.ChangeState(CharacterStateEnums.IDLE);
    }

    public void Move(Vector2 dir)
    {
        controller.moveDirection = dir;

        controller.characterFSM.ChangeState(CharacterStateEnums.MOVE);
    }
}
