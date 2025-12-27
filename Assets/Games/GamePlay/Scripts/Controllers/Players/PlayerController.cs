using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.GamePlay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine _playerStateMachine;

        #region  Init
        public void OnEnable()
        {
            _playerStateMachine.OnEnable();
        }
        public void Start()
        {
            OnInitState();
        }
        public void OnDisable()
        {
            _playerStateMachine.OnDisable();
        }
        public void OnInitState()
        {
            _playerStateMachine.BindPlayerController(this);
            _playerStateMachine.OnInit();
        }
        #endregion
        #region  Unity Method
        private void Update()
        {
            _playerStateMachine?.OnUpdate();
        }
        private void FixedUpdate()
        {
            _playerStateMachine?.OnPhysicUpdate();
        }
        #endregion
        #region  Exposed Method
        public void OnAnimationStartEvent()
        {
            _playerStateMachine.OnAnimationStartEventHandle();
        }
        public void OnAnimationTransitionEvent()
        {
            _playerStateMachine.OnAnimationTransitionEventHandle();
        }
        public void OnAnimationEndEvent()
        {
            _playerStateMachine.OnAnimationEndEventHandle();
        }
        #endregion

    }
}
