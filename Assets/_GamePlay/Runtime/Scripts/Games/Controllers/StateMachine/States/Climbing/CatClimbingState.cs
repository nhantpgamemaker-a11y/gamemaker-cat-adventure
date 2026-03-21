using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatClimbingState : BaseCatState
    {
        private bool _lastHeadColliderStatus = false;
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _lastHeadColliderStatus = stateMachine.HeadCollider.enabled;
            stateMachine.HeadCollider.enabled = false;
            StartBoolAnimation(stateMachine.CatAnimationData.ClimbingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            stateMachine.HeadCollider.enabled = _lastHeadColliderStatus;
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.ClimbingAnimationHash);
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            RotationToWall();
            FloatingOnWall();
        }
        public void RotationToWall()
        {
            var climbingGroundCheckCollider = stateMachine.ClimbingGroundCheckCollider;
            float z = climbingGroundCheckCollider.center.z;
            var bodyColliders = stateMachine.BodyColliders;
            var forward = stateMachine.transform.forward;
            forward.y = 0f;
            for (int i = 0; i < bodyColliders.Length; i++)
            {
                var collider = bodyColliders[i];
                var distance = Mathf.Abs(collider.bounds.center.z - z);
                if (Physics.Raycast(collider.bounds.center, forward, out RaycastHit hitInfo, distance + stateMachine.CatConfigData.ExtraGroundedFloatDistance, stateMachine.CatConfigData.ClimbableLayerMask))
                {
                    var targetRotation = Quaternion.LookRotation(-hitInfo.normal);
                    stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
                    break;
                }
            }
        }
        public void FloatingOnWall()
        {
            var climbingGroundCheckCollider = stateMachine.ClimbingGroundCheckCollider;
            float z = climbingGroundCheckCollider.bounds.center.z;
            var bodyColliders = stateMachine.BodyColliders;
            var forward = stateMachine.transform.forward;
            forward.y = 0f;
            for (int i = 0; i < bodyColliders.Length; i++)
            {
                var collider = bodyColliders[i];
                var distance = Mathf.Abs(collider.bounds.center.z - z);
                if (Physics.Raycast(collider.bounds.center, forward, out RaycastHit hitInfo, distance +
                    stateMachine.CatConfigData.ExtraClimbingGroundFloatDistance, stateMachine.CatConfigData.ClimbableLayerMask))
                {
                    float floatDistance = distance - hitInfo.distance;
                    var liftForce = (-forward * floatDistance * stateMachine.CatConfigData.ClimbingStepFloatingForce) - GetHorizontalVelocity();
                    stateMachine.Rigidbody.AddForce(liftForce, ForceMode.VelocityChange);
                    break;
                }
            }
        }
        public void OnDrawGizmos()
        {
            if(stateMachine == null) return;
            var climbingGroundCheckCollider = stateMachine.ClimbingGroundCheckCollider;
            float z = climbingGroundCheckCollider.bounds.center.z;
            var bodyColliders = stateMachine.BodyColliders;
            var forward = stateMachine.transform.forward;
            forward.y = 0f;
            for (int i = 0; i < bodyColliders.Length; i++)
            {
                var collider = bodyColliders[i];
                var distance = Mathf.Abs(collider.bounds.center.z - z);
                if (Physics.Raycast(collider.bounds.center, forward, out RaycastHit hitInfo, distance + stateMachine.CatConfigData.ExtraClimbingGroundFloatDistance, stateMachine.CatConfigData.ClimbableLayerMask))
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(collider.bounds.center, hitInfo.point);
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(collider.bounds.center, collider.bounds.center + forward * (distance + stateMachine.CatConfigData.ExtraClimbingGroundFloatDistance));
                }
            }
        }
    }
}
