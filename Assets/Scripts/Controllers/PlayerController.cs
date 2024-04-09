
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigid;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PlayerMovementFSM movementFSM;
    public Vector2 moveDirection;
    public Vector2 targetPosition;

    public GameObject weapon;


    private float moveSpeed = 5f;

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

        targetPosition = FindClosestObjectPosition();
        Debug.Log("가장 가까운 객체의 위치: " + targetPosition);

        // weapon.transform.position = (Vector2)transform.position + (targetDirection - (Vector2)transform.position).normalized;
        // 현재 객체의 위치
        Vector2 currentPos = transform.position;
        // 타겟 방향 벡터 계산
        Vector2 directionToTarget = targetPosition - currentPos;
        if (targetPosition == currentPos) directionToTarget = moveDirection;

        spriteRenderer.flipX = directionToTarget.x < 0;
        // 타겟 방향 벡터와 Vector2.up 사이의 각도 계산
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        // Quaternion을 사용하여 weapon 객체 회전 설정
        // Unity에서는 Z축 회전이 2D 회전에 해당합니다.
        // Mathf.Atan2는 라디안 값을 반환하므로 Mathf.Rad2Deg를 곱하여 각도를 도(degrees)로 변환합니다.
        weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
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

    public LayerMask enemyLayer;
    public LayerMask entityLayer;

    Vector2 FindClosestObjectPosition()
    {
        Vector2 playerPosition = transform.position;

        // Enemy 레이어에 대한 탐색
        Vector2? closestEnemyPosition = FindClosestObjectInLayer(playerPosition, 5f, enemyLayer);
        if (closestEnemyPosition != null)
        {
            return closestEnemyPosition.Value;
        }

        // Enemy 객체가 없을 경우, Entity 레이어에 대한 탐색
        Vector2? closestEntityPosition = FindClosestObjectInLayer(playerPosition, 5f, entityLayer);
        if (closestEntityPosition != null)
        {
            return closestEntityPosition.Value;
        }

        // Enemy와 Entity 객체 모두 없을 경우, 플레이어의 위치 반환
        return playerPosition;
    }

    Vector2? FindClosestObjectInLayer(Vector2 center, float radius, LayerMask layer)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius, layer);
        Collider2D closestCollider = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (Collider2D hitCollider in hitColliders)
        {
            Vector2 directionToTarget = hitCollider.transform.position - (Vector3)center;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestCollider = hitCollider;
            }
        }

        if (closestCollider != null)
        {
            return closestCollider.transform.position;
        }

        // 해당 레이어의 객체가 없을 경우 null 반환
        return null;
    }
}
