
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public PlayerMovementFSM movementFSM;
    public Vector2 moveDirection;

    private float moveSpeed = 5f;

    [SerializeField] public Rigidbody2D rigid;

    private void Awake() 
    {
        FSMFactory<PlayerMovementFSM, PlayerMovementStateEnums, PlayerController> factory = new PlayerMovementFSMFactory();
        movementFSM = factory.CreateFSM(this);
    }

    private void Update() 
    {
        if (movementFSM != null)    
        {
            movementFSM.currentState.Update();
        }
    }

    private void FixedUpdate() 
    {
        if (movementFSM != null)
        {
            movementFSM.currentState.FixedUpdate();
        }
    }

    public void Move()
    {
        rigid.velocity = moveDirection * moveSpeed;
    }
}
