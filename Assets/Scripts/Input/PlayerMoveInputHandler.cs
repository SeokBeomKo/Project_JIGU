using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveInputHandler : MonoBehaviour
{
    public delegate void MoveInput(Vector2 dir);
    public event MoveInput onMoveInput;
    Vector2 inputVec;

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        onMoveInput?.Invoke(inputVec);
    }
}
