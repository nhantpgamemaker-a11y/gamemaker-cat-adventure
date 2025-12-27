using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerIdlingState : PlayerGroundState
    {
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Idling;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.IdlingAnimationHash);
            playerStateMachine.PlayerReusableData.SetSpeedModifier(0);
            ResetVelocity();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.IdlingAnimationHash);
        }
    }
}
