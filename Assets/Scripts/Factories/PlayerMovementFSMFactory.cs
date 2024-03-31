using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFSMFactory : FSMFactory<PlayerMovementFSM, PlayerMovementStateEnums, PlayerController>
{
    public override PlayerMovementFSM CreateFSM(PlayerController controller)
    {
        var fsm = new PlayerMovementFSM();

        // 필요한 상태들을 여기서 추가 및 초기화
        fsm.AddState(PlayerMovementStateEnums.IDLE, new PlayerMovementIdleState(controller));
        fsm.AddState(PlayerMovementStateEnums.MOVE, new PlayerMovementMoveState(controller));
        fsm.AddState(PlayerMovementStateEnums.DEAD, new PlayerMovementDeadState(controller));

        return fsm;
    }
}
