using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0, -0.23f, 0);
    Vector3 rightPosReverse = new Vector3(0, -0.23f, 0);

    Quaternion LeftRot = Quaternion.Euler(0, 0, 0);
    Quaternion LeftRotRev = Quaternion.Euler(0, 0, 0);

    private void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    private void LateUpdate()
    {
        bool isReverse = player.flipX;

        
    }
}
