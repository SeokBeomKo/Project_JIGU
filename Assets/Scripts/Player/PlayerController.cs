using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;

    private float moveSpeed = 5f;

    [SerializeField] public Rigidbody2D rigid;

    void FixedUpdate() 
    {
        rigid.velocity = inputVec * moveSpeed;
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
