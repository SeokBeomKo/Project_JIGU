using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyType enemyType;
    public EnemyMovementFSM movementFSM;
    public GameObject target;

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
    }

    private void FixedUpdate()
    {
        if (movementFSM != null)
        {
            movementFSM.currentState.FixedUpdate();
        }
    }
}
