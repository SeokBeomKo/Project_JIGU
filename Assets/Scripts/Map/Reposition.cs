using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public PlayerTest player;
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) return;

        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = player.inputVec;

        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1; // normalized ¾È ÇßÀ¸¸é ±»ÀÌ ¾È ÇØµµ µÊ

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 100);
                }
                else
                {
                    transform.Translate(Vector3.up * dirY * 100);
                }
                break;
            case "Enemy":
                if(coll.enabled)
                {
                    transform.Translate(playerDir * 30 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f)) ; //50 : ¸Ê Å©±â ¸¸Å­
                }
                break;
        }
    }
}
