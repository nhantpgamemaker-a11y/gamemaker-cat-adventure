using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public abstract class PlayerMoveState : PlayerGroundState
    {
         public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.MoveAnimationHash);
        }

        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.MoveAnimationHash);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (playerStateMachine.PlayerReusableData.GetSpeedModifier() == 0 ||
                playerStateMachine.PlayerReusableData.GetControlDirection().x == 0)
            {
                playerStateMachine.ChangeState(PlayerStateType.Idling);
                return;
            }
        }
        protected override void RegisterInputAction()
        {
            playerStateMachine.PlayerInputAction.Player.Jump.performed += OnJumpPerformed;
        }
        protected override void UnRegisterInputAction()
        {
            playerStateMachine.PlayerInputAction.Player.Jump.performed -= OnJumpPerformed;
        }
    }
}