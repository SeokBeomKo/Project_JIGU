using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCharacterController : BaseCharacterController
{

    private void Awake()
    {
        moveSpeed = 0.25f;
        
        var factory = new CharacterMovementFSMFactory();
        characterFSM = factory.CreateFSM(this);
        StartCoroutine(ChangeStateCoroutine());
    }

    private void Update() 
    {
        if (characterFSM != null)    
        {
            characterFSM.currentState.Update();
        }
    }

    private void FixedUpdate() 
    {
        if (characterFSM != null)    
        {
            characterFSM.currentState.FixedUpdate();
        }
    }

    private IEnumerator ChangeStateCoroutine()
    {
        while (true) // 무한 루프로 계속 실행
        {
            ChangeState();

            // 1초에서 5초 사이의 랜덤한 대기 시간
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }

    private void ChangeDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        spriteController.Flip(moveDirection.x < 0);
    }

    private void ChangeSpeed()
    {
        moveSpeed = Random.Range(0.1f, 0.5f);
    }

    private void ChangeState()
    {
        if (Random.Range(0, 2) == 0)
        {
            characterFSM.ChangeState(CharacterStateEnums.IDLE);
        }
        else
        {
            ChangeDirection();
            ChangeSpeed();

            characterFSM.ChangeState(CharacterStateEnums.MOVE);
        }
    }
}
