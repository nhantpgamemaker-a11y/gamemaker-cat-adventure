using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatAirborneState : BaseCatState
    {
        private Collider[] _groundCheckOverlapBoxResults;
        override public void OnEnterState(BaseStateData baseStateData = null)
        {
            _groundCheckOverlapBoxResults = new Collider[1];
            StartBoolAnimation(stateMachine.CatAnimationData.AirborneAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            _groundCheckOverlapBoxResults = null;
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.AirborneAnimationHash);
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            ApplyGravity();
        }
        public void ApplyGravity()
        {
            var gravityAcceleration = Vector3.down * stateMachine.CatConfigData.GravitySpeed;
            stateMachine.Rigidbody.AddForce(gravityAcceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        protected bool IsGrounded()
        {
            var groundCheckCollider = stateMachine.GroundCheckCollider;
            if (Physics.OverlapBoxNonAlloc(groundCheckCollider.bounds.center,
            groundCheckCollider.size / 2f,
            _groundCheckOverlapBoxResults,
            groundCheckCollider.gameObject.transform.rotation,
            stateMachine.CatConfigData.GroundLayerMask) == 0)
            {
                return false;
            }
            return true;
        }
    }
}