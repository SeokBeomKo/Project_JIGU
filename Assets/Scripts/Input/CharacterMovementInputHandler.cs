using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementInputHandler : MonoBehaviour
{
    public delegate void MoveInput(Vector2 dir);
    public event MoveInput onMoveInput;
    public event MoveInput onIdleInput;
    Vector2 inputVec;

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        if (inputVec == Vector2.zero)
        {
            onIdleInput?.Invoke(Vector2.zero);
            return;
        }

        onMoveInput?.Invoke(inputVec);
    }
}
