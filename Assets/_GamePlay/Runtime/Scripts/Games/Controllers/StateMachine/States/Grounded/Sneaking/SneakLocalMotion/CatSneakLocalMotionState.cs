using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatSneakLocalMotionState : CatSneakingState
    {
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            stateMachine.CatReusableData.CurrentSpeedModifier = stateMachine.CatConfigData.SneakSpeed;
            StartBoolAnimation(stateMachine.CatAnimationData.SneakLocalMotionAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            StopBoolAnimation(stateMachine.CatAnimationData.SneakLocalMotionAnimationHash);
            base.OnExitState();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (stateMachine.CatReusableData.CurrentMoveInput == Vector2.zero)
            {
                stateMachine.ChangeState(CatStateType.SneakIdling);
                return;
            }
            if (!IsSneaking())
            {
                stateMachine.ChangeState(CatStateType.Walking);
                return;
            }
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            var moveInput = stateMachine.CatReusableData.CurrentMoveInput;
            if (moveInput == Vector2.zero) return;
            var cameraTransform = Camera.main.transform;

            var forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraTransform.right;
            right.y = 0;
            right.Normalize();

            var moveDirection = forward * moveInput.y + right * moveInput.x;
            if (moveDirection.sqrMagnitude <= 0.0001f) return;
            moveDirection.Normalize();
            var speed = stateMachine.CatReusableData.CurrentSpeedModifier;

            var targetVelocity = moveDirection * speed;
            var angle = Vector3.SignedAngle(stateMachine.transform.forward, moveDirection, Vector3.up);
            angle = Mathf.Abs(angle);
            targetVelocity = GetVelocityMupByAngle(angle) * targetVelocity;
            var currentHorizontalVelocity = GetHorizontalVelocity();
            stateMachine.Rigidbody.AddForce(targetVelocity - currentHorizontalVelocity, ForceMode.VelocityChange);
            Rotation(moveDirection);
        }
        protected virtual float GetVelocityMupByAngle(float angle)
        {
            return 1 - stateMachine.CatConfigData.SpeedSlopeModifierByAngle.Evaluate(angle);
        }
        protected virtual void Rotation(Vector3 moveDirection)
        {
            var desiredRotation = Quaternion.LookRotation(moveDirection);
            var targetRotation = Quaternion.Slerp(
                stateMachine.transform.rotation,
                desiredRotation,
                stateMachine.CatConfigData.RotationSpeed * Time.fixedDeltaTime);
            stateMachine.Rigidbody.MoveRotation(targetRotation);
        }
        public bool IsForward()
        {
            var moveInput = stateMachine.CatReusableData.CurrentMoveInput;
            if (moveInput == Vector2.zero) return false;
            var cameraTransform = Camera.main.transform;

            var forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraTransform.right;
            right.y = 0;
            right.Normalize();

            var moveDirection = forward * moveInput.y + right * moveInput.x;
            if (moveDirection.sqrMagnitude <= 0.0001f) return false;
            moveDirection.Normalize();
            var angle = Vector3.SignedAngle(stateMachine.transform.forward, moveDirection, Vector3.up);
            angle = Mathf.Abs(angle);
            return angle <= stateMachine.CatConfigData.SneakForwardMaxAngle;
        }
    }
}
