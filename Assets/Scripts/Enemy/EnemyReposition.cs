using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReposition : MonoBehaviour
{
    public Collider2D enemyCollider;
    public PlayerTest player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area") || !enemyCollider.enabled) return;

        Vector3 playerDir = player.inputVec;

        transform.Translate(playerDir * 30 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f)); 

    }
}
