using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatDroppingFromEdge : CatDroppingState
    {
        private bool _lastGroundCheckColliderStatus = false;
        private bool _isStartDropping = false;
        public override CatStateType GetStateType()
        {
            return CatStateType.DroppingFromEdge;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _isStartDropping = false;
            _lastGroundCheckColliderStatus = stateMachine.GroundCheckCollider.enabled;
            stateMachine.GroundCheckCollider.enabled = false;
            StartBoolAnimation(stateMachine.CatAnimationData.DroppingFromEdgeAnimationHash);
            base.OnEnterState(baseStateData);
            ResetVelocity();
        }
        override public void OnExitState()
        {
            stateMachine.GroundCheckCollider.enabled = _lastGroundCheckColliderStatus;
            StopBoolAnimation(stateMachine.CatAnimationData.DroppingFromEdgeAnimationHash);
            base.OnExitState();
        }
        protected internal override void OnAnimationStartEvent()
        {
            base.OnAnimationStartEvent();
            AddExtraDroppingForce();
            _isStartDropping = true;
        }
        protected internal override void OnAnimationEndEvent()
        {
            base.OnAnimationEndEvent();
            stateMachine.ChangeState(CatStateType.Falling);
        }
        private void AddExtraDroppingForce()
        {
            var forwardDirection = GetForwardDirection();
            stateMachine.Rigidbody.AddForce(forwardDirection *
                stateMachine.CatConfigData.ExtraDroppingForce, ForceMode.VelocityChange);
        }
        public override void OnFixedUpdate()
        {
            if(_isStartDropping)
            {
                base.OnFixedUpdate();
            }
        }
    }
}
