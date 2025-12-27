using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerJumpingState : PlayerAirborneState
    {
        private float _targetHeight;
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Jumping;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.JumpingAnimationHash);
            _targetHeight = playerStateMachine.GetMinPoint().y + playerStateMachine.PlayerData.MovementData.JumpHeight;
            var hit = Physics2D.Raycast(playerStateMachine.GetCenterBody(), Vector2.up, Mathf.Infinity, playerStateMachine.PlayerData.LayerData.GroundLayer);
            if (hit)
            {
                _targetHeight = Mathf.Min(_targetHeight, hit.point.y);
            }
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            var currentHeight = playerStateMachine.GetMinPoint().y;
            if (currentHeight >= _targetHeight)
            {
                playerStateMachine.ChangeState(PlayerStateType.Falling);
            }
        }
        public override void OnPhysicUpdate()
        {
            var currentHeight = playerStateMachine.GetMinPoint().y;
            var force = Vector2.zero;
            if (currentHeight < _targetHeight)
            {
                float heightDifference = _targetHeight - currentHeight;
                if(heightDifference < 0.01f) heightDifference = 0.01f;
                float liftForce = CalculateLiftForce(heightDifference);
                Vector2 yForce = new Vector2(0f, liftForce);
                force += yForce;
            }
            if(playerStateMachine.PlayerReusableData.GetControlDirection().x !=0f && IsForwardObstacle() == false)
            {
                var direction = playerStateMachine.PlayerReusableData.GetControlDirection();
                direction.y = 0f;
                var normalDirection = direction.normalized;
                var horizontalForce = normalDirection * playerStateMachine.PlayerData.MovementData.BaseSpeed * playerStateMachine.PlayerReusableData.GetSpeedModifier();
                force += horizontalForce;
            }
            playerStateMachine.Rigidbody.linearVelocity = force;
            //base.OnPhysicUpdate();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.JumpingAnimationHash);
        }
        private float CalculateLiftForce(float heightDifference)
        {
            float liftStrength = playerStateMachine.PlayerData.MovementData.HeightCorrectionForce;
            float lift = heightDifference * liftStrength;
            
            float maxLift = playerStateMachine.PlayerData.MovementData.MaxHeightCorrectionForce;
            return Mathf.Clamp(lift, 0f, maxLift);
        }
    }
}
