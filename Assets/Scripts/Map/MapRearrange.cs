using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapRearrange : MonoBehaviour
{
    public Transform[] tileArray = new Transform[9];
    public BoundaryTrigger[] triggerArray = new BoundaryTrigger[9];

    public Vector3 middleTilePosition;


    private Vector3[,] positions = new Vector3[3, 3]; 
    private const int mapSize = 30; // 맵 하나의 크기 30 X 30


    private void Awake()
    {
        int index = 0;
        for (int i = 0; i < 3; i++) // y 축
        {
            for (int j = 0; j < 3; j++) // x 축
            {
                // positions 배열에 Unity 좌표계 매핑 없이 직접적인 위치 설정
                positions[i, j] = new Vector3((j - 1) * mapSize, -(i - 1) * mapSize, 0); // x, y 위치를 30 단위로 조정
                tileArray[index].position = positions[i, j];
                index++;
            }
        }

        for(int i = 0; i < tileArray.Length; i++)
        {
            if(i == 4)
                tileArray[i].GetComponentInChildren<Collider2D>().enabled = true; 
            else
                tileArray[i].GetComponentInChildren<Collider2D>().enabled = false;
        }
    }

    private void Start()
    {
        foreach (var trigger in triggerArray)
        {
            trigger.OnTrigger += Move;
        }
    }


    public void Move(DirectionEnums direction)
    {
        switch (direction)
        {
            case DirectionEnums.RIGHT:
                MoveHorizontal(1);
                break;
            case DirectionEnums.LEFT:
                MoveHorizontal(-1);
                break;
            case DirectionEnums.UP:
                MoveVertical(-1);
                break;
            case DirectionEnums.DOWN:
                MoveVertical(1);
                break;
        }

        UpdateTilePositions();
    }

    private void MoveHorizontal(int step) // 수평 방향
    {
        Vector3[,] newPositions = new Vector3[3, 3];
        
        middleTilePosition.x += step * mapSize;
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int newIndex = (j + step + 3) % 3; // 순환적 이동을 위한 새 인덱스 계산
                newPositions[i, newIndex] = positions[i, j] + new Vector3(mapSize * step, 0, 0); // 실제 위치 변경
            }
        }
        positions = newPositions;
    }

    private void MoveVertical(int step) // 수직 방향
    {
        Vector3[,] newPositions = new Vector3[3, 3];

        middleTilePosition.y -= step * mapSize;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int newIndex = (i + step + 3) % 3; // 순환적 이동을 위한 새 인덱스 계산
                newPositions[newIndex, j] = positions[i, j] - new Vector3(0, mapSize * step, 0); // 실제 위치 변경
            }
        }
        positions = newPositions;
    }

    private void UpdateTilePositions()
    {
        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                bool isMiddleTile = middleTilePosition == positions[i, j];
                tileArray[index].GetComponentInChildren<Collider2D>().enabled = isMiddleTile;
                tileArray[index].position = positions[i, j];

                index++;
            }
        }
    }


}
