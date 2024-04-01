using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFSM<T> : MonoBehaviour
{
    protected Dictionary<T, IState> states = new Dictionary<T, IState>();
    public IState currentState;

    public void AddState(T key, IState state)
    {
        if (!states.ContainsKey(key))
        {
            states[key] = state;
        }
    }

    public void ChangeState(T key)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        if (states.TryGetValue(key, out var newState))
        {
            currentState = newState;
            currentState.Enter();
        }
    }
}
