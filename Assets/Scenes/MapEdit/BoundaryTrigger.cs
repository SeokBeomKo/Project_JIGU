using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    public PlayerTest player;

    public delegate void TriggerHandler(Direction direction);
    public event TriggerHandler OnTrigger;

    private Collider2D Collider;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = player.inputVec;

        if (diffX > diffY)
        {
            if (playerDir.x < 0) OnTrigger?.Invoke(Direction.LEFT);
            else OnTrigger?.Invoke(Direction.RIGHT);
        }
        else
        {
            if (playerDir.y < 0) OnTrigger?.Invoke(Direction.DOWN);
            else OnTrigger?.Invoke(Direction.UP);
        }
    }
}
