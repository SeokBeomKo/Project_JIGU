using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFSMFactory : FSMFactory<EnemyMovementFSM, EnemyStateEnums, EnemyController>
{
    public override EnemyMovementFSM CreateFSM(EnemyController controller)
    {
        EnemyMovementFSM fsm = controller.gameObject.AddComponent<EnemyMovementFSM>();
      
        // 필요한 상태들을 여기서 추가 및 초기화
        fsm.AddState(EnemyStateEnums.CHASE, new EnemyChaseState(controller));
        fsm.AddState(EnemyStateEnums.ATTACKPREPARATION, new EnemyAttackPreparationState(controller));
        fsm.AddState(EnemyStateEnums.ATTACK, new EnemyAttackState(controller));
        fsm.AddState(EnemyStateEnums.STIFFEN, new EnemyStiffenState(controller));
        fsm.AddState(EnemyStateEnums.DEAD, new EnemyDeadState(controller));

        fsm.ChangeState(EnemyStateEnums.CHASE);

        return fsm;
    }
}
