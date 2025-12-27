using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerRunningState : PlayerMoveState
    {
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Running;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.RunningAnimationHash);
            playerStateMachine.PlayerReusableData.SetSpeedModifier(playerStateMachine.PlayerData.MovementData.RunningSpeedModifier);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.RunningAnimationHash);
        }
        public override void OnPhysicUpdate()
        {
            base.OnPhysicUpdate();
            var direction = playerStateMachine.PlayerReusableData.GetControlDirection();
            direction.y = 0f;
            var normalDirection = direction.normalized;
            var force = normalDirection * playerStateMachine.PlayerData.MovementData.BaseSpeed * playerStateMachine.PlayerReusableData.GetSpeedModifier();
            var verticalVelocity = GetVerticalVelocity();
            force += verticalVelocity;
            playerStateMachine.Rigidbody.linearVelocity = force;
        }
    }
}
