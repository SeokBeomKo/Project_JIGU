using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public IEnumerator RemoveProjectile(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
