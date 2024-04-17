using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;


    Rigidbody2D rigid;
    SpriteRenderer sprite;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        // inputVec.magnitude; //벡터의 순수한 크기 값

        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }
}
