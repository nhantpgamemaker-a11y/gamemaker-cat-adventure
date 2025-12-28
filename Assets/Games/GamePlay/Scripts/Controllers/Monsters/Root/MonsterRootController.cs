using System;
using UnityEngine;

namespace Game.GamePlay
{
    public class MonsterRootController: MonoBehaviour
    {
        [SerializeField] private MonsterRootStateMachine _monsterStateMachine;
         
         public void Start()
        {
            OnInitState();
        }

        private void OnInitState()
        {
            _monsterStateMachine.BindController(this);
            _monsterStateMachine.OnInit();
        }
         #region  Exposed Method
        public void OnAnimationStartEvent()
        {
            _monsterStateMachine.OnAnimationStartEventHandle();
        }
        public void OnAnimationTransitionEvent()
        {
            _monsterStateMachine.OnAnimationTransitionEventHandle();
        }
        public void OnAnimationEndEvent()
        {
            _monsterStateMachine.OnAnimationEndEventHandle();
        }
        #endregion
    }
}