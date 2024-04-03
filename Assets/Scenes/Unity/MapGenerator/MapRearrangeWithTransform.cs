using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRearrangeWithTransform : MonoBehaviour
{
    public Transform[] tiles = new Transform[9];
    private Vector3[,] positions = new Vector3[3, 3];

    private void Start()
    {
        int index = 0;
        for (int i = 0; i < 3; i++) // y 축에 대응
        {
            for (int j = 0; j < 3; j++) // x 축에 대응
            {
                // positions 배열에 직접적인 Unity 좌표계 매핑 없이 위치 설정
                positions[i, j] = new Vector3(j - 1, -(i - 1), 0); // x, y 위치 조정
                tiles[index].position = positions[i, j];
                index++;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                MoveHorizontal(1);
                break;
            case Direction.Left:
                MoveHorizontal(-1);
                break;
            case Direction.Up:
                MoveVertical(-1);
                break;
            case Direction.Down:
                MoveVertical(1);
                break;
        }

        UpdateTilePositions();
    }

    private void MoveHorizontal(int step)
    {
        Vector3[,] newPositions = new Vector3[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int newIndex = (j + step + 3) % 3;
                newPositions[i, newIndex] = positions[i, j];
            }
        }
        positions = newPositions;
    }

    private void MoveVertical(int step)
    {
        Vector3[,] newPositions = new Vector3[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int newIndex = (i + step + 3) % 3;
                newPositions[newIndex, j] = positions[i, j];
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
                tiles[index].position = positions[i, j];
                index++;
            }
        }
    }

    // 테스트를 위한 간단한 입력 처리
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Direction.Right);
        }
    }
}
