using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatDroppingFromWall : CatDroppingState
    {
        private Vector3 _lastForwardDirection;
        private bool _isStartDropping = false;
        public override CatStateType GetStateType()
        {
            return CatStateType.DroppingFromWall;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _isStartDropping = false;
            _lastForwardDirection = stateMachine.transform.forward;
            StartBoolAnimation(stateMachine.CatAnimationData.DroppingFromWallAnimationHash);
            base.OnEnterState(baseStateData);
            ResetVelocity();
        }
        public override void OnFixedUpdate()
        {
            //base.OnFixedUpdate();
            if(_isStartDropping)
            {
                RotationToForwardDirection(-_lastForwardDirection);
                //ApplyGravity();
            }
        }
        public override void OnExitState()
        {
            _lastForwardDirection = Vector3.zero;
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.DroppingFromWallAnimationHash);
        }
        protected void RotationToForwardDirection(Vector3 forwardDirection)
        {
            forwardDirection.y = 0;
            var targetRotation = Quaternion.LookRotation(forwardDirection);
            stateMachine.Rigidbody.MoveRotation(Quaternion.RotateTowards(stateMachine.transform.rotation,
            targetRotation, stateMachine.CatConfigData.ClimbingRotationSpeed));
        }
        protected internal override void OnAnimationStartEvent()
        {
            base.OnAnimationStartEvent();
            _isStartDropping = true;
        }
        override protected internal void OnAnimationEndEvent()
        {
            base.OnAnimationEndEvent();
            stateMachine.ChangeState(CatStateType.Falling);
        }
    }
}
