using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 directionVector = target.position - rigid.position; // πÊ«‚
        Vector2 nextVector = directionVector.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVector);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
            return;

        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }
    
}