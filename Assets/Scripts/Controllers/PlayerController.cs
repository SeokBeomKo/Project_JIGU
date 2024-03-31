
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerMovementFSM movementFSM;
    public Vector2 inputVec;

    private float moveSpeed = 5f;

    [SerializeField] public Rigidbody2D rigid;

    private void Update() 
    {
        if (movementFSM != null)    movementFSM.currentState.Update();
    }

    private void FixedUpdate() 
    {
        if (movementFSM != null)    movementFSM.currentState.FixedUpdate();
    }

    public void Move()
    {
        rigid.velocity = inputVec * moveSpeed;
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
