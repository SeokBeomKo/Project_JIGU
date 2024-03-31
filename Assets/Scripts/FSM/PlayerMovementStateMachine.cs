using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    [Header("플레이어 컨트롤러")]
    [SerializeField] public PlayerController playerController;
    [HideInInspector] public IState curState;

    public Dictionary<PlayerMovementStateEnums, IState> stateDictionary;

    private void Awake() 
    {
        stateDictionary = new Dictionary<PlayerMovementStateEnums, IState>
        {
            // {PlayerMovementStateEnums.IDLE,             new PlayerMovementIdleState(this)},
            // {PlayerMovementStateEnums.MOVE,             new PlayerMovementMoveState(this)},

            // {PlayerMovementStateEnums.DEAD,             new PlayerMovementDeadState(this)},
        };

        if (stateDictionary.TryGetValue(PlayerMovementStateEnums.IDLE, out IState newState))
        {
            curState = newState;
            curState.Enter();
        }
    }
}
