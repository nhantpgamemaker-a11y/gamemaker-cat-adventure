using System;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    public abstract class CatGroundedState : BaseCatState
    {
        private Collider[] _sneakOverlapBoxResults;
        private Collider[] _droppingOverlapBoxResults;
        private Collider[] _climbingOverlapBoxResults;
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _sneakOverlapBoxResults = new Collider[1];
            _droppingOverlapBoxResults = new Collider[1];
            _climbingOverlapBoxResults = new Collider[1];
            StartBoolAnimation(stateMachine.CatAnimationData.GroundedAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            _sneakOverlapBoxResults = null;
            _droppingOverlapBoxResults = null;
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.GroundedAnimationHash);
        }
        protected override void RegisterInputActions()
        {
            base.RegisterInputActions();
            stateMachine.CatInputAction.Cat.Move.started += OnMoveStated;
        }
        protected override void UnRegisterInputActions()
        {
            base.UnRegisterInputActions();
            stateMachine.CatInputAction.Cat.Move.started -= OnMoveStated;
        }
        protected virtual void OnMoveStated(InputAction.CallbackContext context)
        {

        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            UpdateTargetForwardAngle();
        }
        override public void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            FloatHandle();
        }
        protected virtual void UpdateTargetForwardAngle()
        {
            var moveInput = stateMachine.CatReusableData.CurrentMoveInput;
            var cameraTransform = Camera.main?.transform;
            if (cameraTransform == null) return;

            var forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraTransform.right;
            right.y = 0;
            right.Normalize();

            var moveDirection = forward * moveInput.y + right * moveInput.x;
            if (moveDirection.sqrMagnitude <= 0.0001f) return;

            moveDirection.Normalize();
            var targetAngle = Vector3.SignedAngle(stateMachine.transform.forward, moveDirection, Vector3.up);
            stateMachine.CatReusableData.TargetForwardAngle = targetAngle;

            var currentAngle = stateMachine.CatReusableData.CurrentForwardAngle;
            var velocity = stateMachine.CatReusableData.CurrentForwardAngleVelocity;

            var smoothAngle = Mathf.SmoothDamp(
                currentAngle,
                targetAngle,
                ref velocity,
                stateMachine.CatConfigData.RotationSmoothTime);

            stateMachine.CatReusableData.CurrentForwardAngle = smoothAngle;
            stateMachine.CatReusableData.CurrentForwardAngleVelocity = velocity;

            SetFloatAnimation(stateMachine.CatAnimationData.TargetForwardAngleAnimationHash, smoothAngle);
        }
        protected virtual void FloatHandle()
        {
            var groundCheckCollider = stateMachine.GroundCheckCollider;
            var bodyColliders = stateMachine.BodyColliders;
            var groundLayerMask = stateMachine.CatConfigData.GroundLayerMask;
            for (int i = 0; i < bodyColliders.Length; i++)
            {
                var bodyCollider = bodyColliders[i];
                var direction = Vector3.down;
                var y = bodyCollider.bounds.center.y - groundCheckCollider.bounds.min.y;
                var distance = y + stateMachine.CatConfigData.ExtraGroundedFloatDistance;
                if (Physics.Raycast(bodyCollider.bounds.center, direction, out var hitInfo, distance, groundLayerMask))
                {
                    var floatDistance = y - hitInfo.distance;
                    var verticalVelocity = GetVerticalVelocity();
                    var liftForce = new Vector3(0f, floatDistance * stateMachine.CatConfigData.StepFloatingForce);
                    liftForce = liftForce - verticalVelocity;
                    stateMachine.Rigidbody.AddForce(liftForce, ForceMode.VelocityChange);
                    break;
                }
            }
        }
        protected bool IsSneaking()
        {
            var sneakingCheckCollider = stateMachine.SneakCheckCollider;
            if (Physics.OverlapBoxNonAlloc(sneakingCheckCollider.bounds.center,
            sneakingCheckCollider.size / 2f,
            _sneakOverlapBoxResults,
            sneakingCheckCollider.gameObject.transform.rotation,
            stateMachine.CatConfigData.SneakableLayerMask) != 0)
            {
                return true;
            }
            return false;
        }
        protected bool IsClimbing()
        {
            var climbingCheckCollider = stateMachine.ClimbingCheckCollider;
            if (Physics.OverlapBoxNonAlloc(climbingCheckCollider.bounds.center,
            climbingCheckCollider.size / 2f,
            _climbingOverlapBoxResults,
            climbingCheckCollider.gameObject.transform.rotation,
            stateMachine.CatConfigData.ClimbableLayerMask) != 0)
            {
                return true;
            }
            return false;
        }
        public void OnDrawGizmos()
        {
            var groundCheckCollider = stateMachine.GroundCheckCollider;
            var bodyColliders = stateMachine.BodyColliders;
            for (int i = 0; i < bodyColliders.Length; i++)
            {
                var bodyCollider = bodyColliders[i];
                var direction = Vector3.down;
                var y = bodyCollider.bounds.center.y - groundCheckCollider.bounds.min.y;
                var distance = y + stateMachine.CatConfigData.ExtraGroundedFloatDistance;
                Gizmos.color = Color.red;
                Gizmos.DrawLine(bodyCollider.bounds.center, bodyCollider.bounds.center + direction * distance);
            }
        }
        protected bool IsDropping()
        {
            var droppingCheckCollider = stateMachine.DropCheckCollider;
            if(Physics.OverlapBoxNonAlloc(droppingCheckCollider.bounds.center,
            droppingCheckCollider.size / 2f,
            _droppingOverlapBoxResults,
            droppingCheckCollider.gameObject.transform.rotation,
            stateMachine.CatConfigData.DroppingLayerMask) != 0)
            {
                return false;
            }
            return true;
        }
    }
}