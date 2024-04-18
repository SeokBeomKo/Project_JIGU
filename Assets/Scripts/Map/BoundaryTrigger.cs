using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    public PlayerTest player;

    public delegate void TriggerHandler(DirectionEnums direction);
    public event TriggerHandler OnTrigger;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Vector3 playerPosition = player.transform.position;
        Vector3 myPosition = transform.position;

        float distanceX = Mathf.Abs(playerPosition.x - myPosition.x);
        float distanceY = Mathf.Abs(playerPosition.y - myPosition.y);

        Vector3 playerDirection = player.inputVec;
        DirectionEnums direction;

        if (distanceX > distanceY)
        {
            direction = playerDirection.x < 0 ? DirectionEnums.LEFT : DirectionEnums.RIGHT;
        }
        else
        {
            direction = playerDirection.y < 0 ? DirectionEnums.DOWN : DirectionEnums.UP;
        }

        OnTrigger?.Invoke(direction);
    }
}
