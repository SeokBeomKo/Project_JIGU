using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteController : MonoBehaviour
{
    public Sprite[] spriteArray;            // 선택된 캐릭터 스프라이트
    public SpriteRenderer[] rendererArray;  // 실제 캐릭터 스프라이트 렌더러 배열

    private bool isFacingLeft = false;

    private void Awake()
    {
        // 초기 스프라이트 할당
        for (int i = 0; i < rendererArray.Length; i++)
        {
            rendererArray[i].sprite = spriteArray[i];
        }
    }

    public void Flip(bool isLeft)
    {
        // 방향 변경이 있을 때만 실행
        if (isFacingLeft != isLeft)
        {
            isFacingLeft = isLeft; // 현재 방향 상태 업데이트
            for (int i = 0; i < spriteArray.Length; i++)
            {
                rendererArray[i].flipX = isLeft;
            }

            // 위치 조정
            AdjustPositions();
        }
    }

    private void AdjustPositions()
    {
        // 팔과 다리에 해당하는 렌더러들의 위치만 조정
        for (int i = 2; i < spriteArray.Length; i++) // 인덱스 [2]부터 [5]까지 조정
        {
            Vector3 localPos = rendererArray[i].transform.localPosition;
            rendererArray[i].transform.localPosition = new Vector3(-localPos.x, localPos.y, localPos.z);
        }
    }
}
