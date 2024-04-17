using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : EnemyProjectile
{
    [Header("발사체 속도")]
    public float projectileSpeed;

    [Header("발사체 삭제 시간")]
    public float removeTime;

    [HideInInspector]
    public Vector2 projectileDirection;

    [HideInInspector]
    public Quaternion projectileAngle;

    private void Start()
    {
        transform.rotation = projectileAngle;
        StartCoroutine(RemoveProjectile(removeTime));
    }
    private void FixedUpdate()
    {
        transform.position += (Vector3)projectileDirection.normalized * projectileSpeed * Time.fixedDeltaTime;
    }

    public void SetAngle(Quaternion angle)
    {
        projectileAngle = angle;
    }

    public void SetDirection(Vector2 direction)
    {
        projectileDirection = direction;
    }
}
