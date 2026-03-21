using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    public enum RightStickStateType
    {
        Empty,
        Pan,
        Zoom,
    }
    public class RightStickStateMachine : MonoBehaviour, IStateMachine<RightStickStateType>
    {
        private Dictionary<RightStickStateType, BaseRightStickState> _stateLookup;
        private RightStickStateType _currentStateType;
        private BaseRightStickState _currentState;
        private Gamepad _virtualGamepad;
        public Gamepad VirtualGamepad => _virtualGamepad;
        public void ChangeState(RightStickStateType stateType, BaseStateData baseStateData = null)
        {
            _currentState?.OnExitState();
            _currentStateType = stateType;
            _currentState = _stateLookup[_currentStateType];
            _currentState?.OnEnterState(baseStateData);
        }

        public void OnInit(List<IState<RightStickStateType>> states)
        {
            _stateLookup = new();
            _virtualGamepad =  InputSystem.AddDevice<Gamepad>();
            foreach(var state in states)
            {
                (state as BaseRightStickState).SetStateMachine(this);
                _stateLookup[state.GetStateType()] = state as BaseRightStickState;
                (state as BaseRightStickState).OnInit();
            }
        }

        internal void OnDragHandle(PointerEventData[] pointers, int pointerCount)
        {
            _currentState?.OnDragHandle(pointers, pointerCount);
        }

        internal void OnPointerDownHandle(PointerEventData[] pointers, int pointerCount)
        {
            _currentState?.OnPointerDownHandle(pointers, pointerCount);
        }

        internal void OnPointerUpHandle(PointerEventData[] pointers, int pointerCount)
        {
            _currentState?.OnPointerUpHandle(pointers, pointerCount);
        }

        IState<RightStickStateType> IStateMachine<RightStickStateType>.GetCurrentState()
        {
            return _currentState;
        }

        RightStickStateType IStateMachine<RightStickStateType>.GetCurrentStateType()
        {
            return _currentStateType;
        }

        Dictionary<RightStickStateType, IState<RightStickStateType>> IStateMachine<RightStickStateType>.GetStatesLookup()
        {
            var lookup = new Dictionary<RightStickStateType, IState<RightStickStateType>>();
            foreach (var kvp in _stateLookup)
            {
                lookup[kvp.Key] = kvp.Value;
            }
            return lookup;
        }
    }
}