using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public EnemyType enemyType;
    public EnemyMovementFSM movementFSM;
    public Rigidbody2D target;

    private void Awake()
    {
        FSMFactory<EnemyMovementFSM, EnemyStateEnums, EnemyController> factory = new EnemyMovementFSMFactory();
        movementFSM = factory.CreateFSM(this);
    }

    private void Update()
    {
        if (movementFSM != null)
        {
            movementFSM.currentState.Update();
        }
        // Debug.Log(movementFSM.currentState);
    }

    private void FixedUpdate()
    {
        if (movementFSM != null)
        {
            movementFSM.currentState.FixedUpdate();
        }
    }
}
