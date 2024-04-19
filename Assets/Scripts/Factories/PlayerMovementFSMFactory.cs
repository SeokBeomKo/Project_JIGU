using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSMFactory : FSMFactory<CharacterMovementFSM, CharacterStateEnums, UserCharacterController>
{
    public override CharacterMovementFSM CreateFSM(UserCharacterController controller)
    {
        CharacterMovementFSM fsm = controller.gameObject.AddComponent<CharacterMovementFSM>();

        // 필요한 상태들을 여기서 추가 및 초기화
        fsm.AddState(CharacterStateEnums.IDLE, new CharacterIdleState(controller));
        fsm.AddState(CharacterStateEnums.MOVE, new CharacterMoveState(controller));
        fsm.AddState(CharacterStateEnums.DEAD, new CharacterDeadState(controller));

        fsm.ChangeState(CharacterStateEnums.IDLE);

        return fsm;
    }
}
