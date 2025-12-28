using System;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.GamePlay
{
    public abstract class PlayerAttackState : PlayerGroundState
    {
        protected bool _onTransition = false;
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _onTransition = false;
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.AttackAnimationHash);
            ResetVelocity();

        }
        public override void OnExitState()
        {
            _onTransition = false;
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.AttackAnimationHash);
        }
        internal override void OnAnimationTransitionEventHandle()
        {
            _onTransition = true;
        }

        internal override void OnAnimationEndEventHandle()
        {
            if (playerStateMachine.PlayerReusableData.GetControlDirection() != Vector2.zero)
            {
                playerStateMachine.ChangeState(PlayerStateType.Running);
            }
            else
            {
                playerStateMachine.ChangeState(PlayerStateType.Idling);
            }
        }
        protected override void RegisterInputAction()
        {
            playerStateMachine.PlayerInputAction.Player.Attack.started += OnAttackStarted;
        }
        protected override void UnRegisterInputAction()
        {
            playerStateMachine.PlayerInputAction.Player.Attack.started -= OnAttackStarted;
        }
        private void OnAttackStarted(InputAction.CallbackContext context)
        {
            if (!_onTransition) return;
            NextAttack();
        }
        public virtual void NextAttack()
        {
            
        }
    }
}
