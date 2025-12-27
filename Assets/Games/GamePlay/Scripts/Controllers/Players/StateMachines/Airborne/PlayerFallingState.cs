using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerFallingState : PlayerAirborneState
    {
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Falling;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.FallingAnimationHash);
        }
        public override void OnPhysicUpdate()
        {
            Vector2 yForce = new Vector2(0f, playerStateMachine.PlayerData.MovementData.GravityForce);
            var force = yForce;
            if(playerStateMachine.PlayerReusableData.GetControlDirection().x !=0f && IsForwardObstacle() == false)
            {
                var direction = playerStateMachine.PlayerReusableData.GetControlDirection();
                direction.y = 0f;
                var normalDirection = direction.normalized;
                var horizontalForce = normalDirection * playerStateMachine.PlayerData.MovementData.BaseSpeed * playerStateMachine.PlayerReusableData.GetSpeedModifier();
                force += horizontalForce;
            }
            playerStateMachine.Rigidbody.linearVelocity = force;
            base.OnPhysicUpdate();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.FallingAnimationHash);
        }
    }
}
