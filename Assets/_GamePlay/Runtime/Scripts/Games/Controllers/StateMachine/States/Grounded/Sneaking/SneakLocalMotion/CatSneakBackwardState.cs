using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatSneakBackwardState : CatSneakLocalMotionState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.SneakBackward;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.SneakBackwardAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            StopBoolAnimation(stateMachine.CatAnimationData.SneakBackwardAnimationHash);
            base.OnExitState();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (IsForward())
            {
                stateMachine.ChangeState(CatStateType.SneakForward);
                return;
            }
        }
        protected override float GetVelocityMupByAngle(float angle)
        {
            return 1 - stateMachine.CatConfigData.SpeedSlopeModifierByAngle.Evaluate(180f-angle);
        }
        protected override void Rotation(Vector3 moveDirection)
        {
            moveDirection = -moveDirection;
            var desiredRotation = Quaternion.LookRotation(moveDirection);
            var targetRotation = Quaternion.Slerp(
                stateMachine.transform.rotation,
                desiredRotation,
                stateMachine.CatConfigData.RotationSpeed * Time.fixedDeltaTime);
            stateMachine.Rigidbody.MoveRotation(targetRotation);
        }
        protected override void UpdateTargetForwardAngle()
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

            moveDirection = -moveDirection;
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
    }
}