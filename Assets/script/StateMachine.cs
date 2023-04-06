using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : Enum
{
    // 1. la state machine puo essere in un unico stato
    // 2. gli stati sono finiti (numero preciso di stati)

    private Dictionary<T, State> _states = new();
    private State _currentState;

    //registerState(T type, State state) => Aggiungere lo stato nel dictionary =>_state.add(type,State)

    public void RegisterState(T type, State state)
    {
        if (_states.ContainsKey(type))
        {
            throw new Exception("Stato gia presente: " + type);
        }

        _states.Add(type, state);
    }
    //SetState (T type) => imposta lo stato attuale come lo stato type preso dal dictonary => _ currentState=_state[type];

    public void SetState(T type)
    {
        if (!_states.ContainsKey(type))
        {
            throw new Exception("Stato non registrato: " + type);
        }

        _currentState?.OnExit();

        _currentState = _states[type];

        _currentState.OnEnter();
    }
    //Update() => chiama la funzione update dello stato attuale => _ current staste

    public void Update()
    {
        _currentState?.OnUpdate();
    }

}
