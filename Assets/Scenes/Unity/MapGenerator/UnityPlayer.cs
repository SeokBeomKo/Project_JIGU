using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어의 움직임 속도

    // Update is called once per frame
    void Update()
    {
        // 입력을 받아 플레이어를 움직입니다.
        float moveX = Input.GetAxisRaw("Horizontal"); // 좌우 방향키 입력
        float moveY = Input.GetAxisRaw("Vertical"); // 상하 방향키 입력

        // 현재 위치에서 입력받은 값에 따라 새 위치를 계산합니다.
        Vector3 moveDirection = new Vector3(moveX, moveY).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
