using System;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public abstract class PlayerAirborneState : BasePlayerState
    {
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.AirborneAnimationHash);
            playerStateMachine.PlayerReusableData.SetSpeedModifier(playerStateMachine.PlayerData.MovementData.AirborneSpeedModifier);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.AirborneAnimationHash);
        }
        public override void OnPhysicUpdate()
        {
            base.OnPhysicUpdate();
            GroundHandle();
        }
        protected bool IsForwardObstacle()
        {
            var centerPoint = playerStateMachine.GetMinPoint();
            var direction = playerStateMachine.PlayerReusableData.GetControlDirection();
            var distance = playerStateMachine.Collider2D.bounds.extents.x;
            direction.y = 0f;
            centerPoint.y += 0.1f/2f;
            var normalDirection = direction.normalized;
            var hit = Physics2D.CircleCast(centerPoint, 0.01f, normalDirection, distance + 0.1f/2f, playerStateMachine.PlayerData.LayerData.GroundLayer);
            return hit;
        }
        private void GroundHandle()
        {
            var centerPoint = playerStateMachine.GetCenterBody();
            var bottomPoint = playerStateMachine.GetMinPoint();
            var direction = bottomPoint - centerPoint;
            var size = playerStateMachine.GroundCheckCollider.bounds.size;
            size.y = size.x;
            var hit = Physics2D.BoxCast(centerPoint, size,0, direction, direction.magnitude - size.x/2f, playerStateMachine.PlayerData.LayerData.GroundLayer);
            if (hit)
            {
                playerStateMachine.ChangeState(PlayerStateType.Landing);
            }
        }
        void OnDrawGizmos()
        {
            if (playerStateMachine == null) return;
            if(Application.isPlaying == false) return;
            var centerPoint = playerStateMachine.GetCenterBody();
            var bottomPoint = playerStateMachine.GetMinPoint();
            var direction = bottomPoint - centerPoint;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(centerPoint, bottomPoint + direction.normalized * 0.01f);
        }
    }
}
