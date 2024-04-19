using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementFSMFactory : FSMFactory<CharacterMovementFSM, CharacterStateEnums, BaseCharacterController>
{
    public override CharacterMovementFSM CreateFSM(BaseCharacterController controller)
    {
        var fsm = controller.gameObject.AddComponent<CharacterMovementFSM>();

        fsm.AddState(CharacterStateEnums.IDLE, new CharacterIdleState(controller));
        fsm.AddState(CharacterStateEnums.MOVE, new CharacterMoveState(controller));
        fsm.AddState(CharacterStateEnums.DEAD, new CharacterDeadState(controller));

        fsm.ChangeState(CharacterStateEnums.IDLE);

        return fsm;
    }
}


public class AutoCharacterMovementFSMFactory : FSMFactory<CharacterMovementFSM, CharacterStateEnums, AutoCharacterController>
{
    public override CharacterMovementFSM CreateFSM(AutoCharacterController controller)
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
