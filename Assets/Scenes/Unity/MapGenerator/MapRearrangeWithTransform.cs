using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}


public class MapRearrangeWithTransform : MonoBehaviour
{
    public Transform[] tiles = new Transform[9];
    public BoundaryTrigger[] triggerArray = new BoundaryTrigger[9];

    public Vector3 middleTilePosition;


    private Vector3[,] positions = new Vector3[3, 3]; 
    private int mapSize = 30; // 맵 하나의 크기 30 X 30


    private void Awake()
    {
        int index = 0;
        for (int i = 0; i < 3; i++) // y 축
        {
            for (int j = 0; j < 3; j++) // x 축
            {
                // positions 배열에 Unity 좌표계 매핑 없이 직접적인 위치 설정
                positions[i, j] = new Vector3((j - 1) * mapSize, -(i - 1) * mapSize, 0); // x, y 위치를 30 단위로 조정
                tiles[index].position = positions[i, j];
                index++;
            }
        }

        for(int i = 0; i < tiles.Length; i++)
        {
            if(i == 4) 
                tiles[i].GetComponentInChildren<Collider2D>().enabled = true; 
            else
                tiles[i].GetComponentInChildren<Collider2D>().enabled = false;
        }
    }

    private void Start()
    {
        for (int i = 0; i < triggerArray.Length; i++)
        {
            triggerArray[i].OnTrigger += Move;
        }
    }


    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.RIGHT:
                MoveHorizontal(1);
                break;
            case Direction.LEFT:
                MoveHorizontal(-1);
                break;
            case Direction.UP:
                MoveVertical(-1);
                break;
            case Direction.DOWN:
                MoveVertical(1);
                break;
        }

        UpdateTilePositions();
    }

    private void MoveHorizontal(int step) // 수평 방향
    {
        middleTilePosition.x += step;

        Vector3[,] newPositions = new Vector3[3, 3];
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
        middleTilePosition.y -= step;

        Vector3[,] newPositions = new Vector3[3, 3];
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
                tiles[index].GetComponentInChildren<Collider2D>().enabled = middleTilePosition * mapSize == positions[i, j];
                tiles[index].position = positions[i, j];

                index++;
            }
        }
    }


    // 테스트를 위한 간단한 입력 처리
/*    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Direction.UP);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Direction.DOWN);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Direction.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Direction.RIGHT);
        }
    }*/

}
