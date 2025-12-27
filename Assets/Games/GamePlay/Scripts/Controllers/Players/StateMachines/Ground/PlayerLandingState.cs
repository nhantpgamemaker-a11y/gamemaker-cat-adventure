using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerLandingState : PlayerGroundState
    {
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Landing;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.LandingAnimationHash);
            playerStateMachine.PlayerReusableData.SetSpeedModifier(0);
            ResetVelocity();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.LandingAnimationHash);
        }
        internal override void OnAnimationEndEventHandle()
        {
            var directionControl = playerStateMachine.PlayerReusableData.GetControlDirection();
            if (directionControl.x != 0f)
            {
                playerStateMachine.ChangeState(PlayerStateType.Running);
            }
            else
            {
                playerStateMachine.ChangeState(PlayerStateType.Idling);
            }
        }
    }
}
