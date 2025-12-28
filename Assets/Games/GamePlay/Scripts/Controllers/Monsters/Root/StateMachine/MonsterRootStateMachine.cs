using System;
using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using GamePlay.Game;
using UnityEngine;

namespace Game.GamePlay
{
    public enum MonsterRootStateType
    {
        Idling,
        RightAttack,
        LeftAttack
    }
    [System.Serializable]
    public class MonsterRootStateMachine : BaseStateMachine<MonsterRootStateType>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private RootMonsterData _rootMonsterData;
        protected BaseMonsterRootState CurrentState;
        private MonsterRootController _monsterRootController;
        public RootMonsterData RootMonsterData => _rootMonsterData;
        public void OnInit()
        {
            var states = _monsterRootController.gameObject.GetComponents<BaseMonsterRootState>().ToList();
            OnInit(states.Cast<IState<MonsterRootStateType>>().ToList());
        }
        public override void OnInit(List<IState<MonsterRootStateType>> states)
        {
            base.OnInit(states);
            _rootMonsterData.OnInit();
            ChangeState(MonsterRootStateType.Idling);
        }

        internal void BindController(MonsterRootController monsterRootController)
        {
            _monsterRootController = monsterRootController;
        }
        internal void OnAnimationStartEventHandle()
        {
            CurrentState.OnAnimationStartEventHandle();
        }

        internal void OnAnimationTransitionEventHandle()
        {
            CurrentState.OnAnimationTransitionEventHandle();
        }

        internal void OnAnimationEndEventHandle()
        {
            CurrentState.OnAnimationEndEventHandle();
        }

        internal void StartAnimation(int hashId)
        {
            _animator.SetBool(hashId, true);
        }

        internal void StopAnimation(int hashId)
        {
            _animator.SetBool(hashId, false);
        }
    }
}