using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    [HideInInspector] public CharacterMovementFSM characterFSM;

    [SerializeField] public Rigidbody2D rigid;
    [SerializeField] public Animator animator;
    public CharacterSpriteController spriteController;

    public Vector2 moveDirection;
    public float moveSpeed = 10f;


    public void Move()
    {
        rigid.velocity = moveDirection * moveSpeed;
    }
}
