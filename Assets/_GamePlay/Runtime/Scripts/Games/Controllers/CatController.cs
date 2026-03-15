using System;
using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatController : MonoBehaviour
    {
        [Header("State Machine")]
        [UnityEngine.SerializeField]
        private CatStateMachine _stateMachine;
        [UnityEngine.SerializeField]
        private List<BaseCatState> _states;
        private void Awake()
        {
            OnInit();
        }
        public void OnInit()
        {
            _stateMachine.OnInit(_states.Cast<IState<CatStateType>>().ToList());
        }
        private void Update()
        {
            _stateMachine.OnUpdate();
        }
        private  void FixedUpdate() 
        {
            _stateMachine.OnFixedUpdate();
        }

        internal void OnAnimationStartEvent()
        {
            _stateMachine.OnAnimationStartEvent();
        }

        internal void OnAnimationTransitionEvent()
        {
            _stateMachine.OnAnimationTransitionEvent();
        }

        internal void OnAnimationEndEvent()
        {
            _stateMachine.OnAnimationEndEvent();
        }
    }
}
