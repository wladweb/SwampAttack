﻿using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _initialState;

    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_initialState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
