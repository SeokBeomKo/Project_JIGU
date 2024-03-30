using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2 inputVec;

    private float moveSpeed = 5f;

    [SerializeField] public Rigidbody2D rigid;

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    {
        rigid.velocity = inputVec.normalized * moveSpeed;
    }
}
