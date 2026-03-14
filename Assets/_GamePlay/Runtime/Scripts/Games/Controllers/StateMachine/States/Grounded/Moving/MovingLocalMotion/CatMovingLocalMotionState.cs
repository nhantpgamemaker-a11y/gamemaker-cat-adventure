using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatMovingLocalMotionState : CatMovingState
    {
        override public void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.MovingLocalMotionAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.MovingLocalMotionAnimationHash);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if(stateMachine.CatReusableData.CurrentMoveInput == Vector2.zero)
            {
                stateMachine.ChangeState(CatStateType.Idling);
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
            targetVelocity = (1 - stateMachine.CatConfigData.SpeedSlopeModifierByAngle.Evaluate(angle)) * targetVelocity;
            var currentHorizontalVelocity = GetHorizontalVelocity();
            stateMachine.Rigidbody.AddForce(targetVelocity - currentHorizontalVelocity, ForceMode.VelocityChange);

            var desiredRotation = Quaternion.LookRotation(moveDirection);
            var targetRotation = Quaternion.Slerp(
                stateMachine.transform.rotation,
                desiredRotation,
                stateMachine.CatConfigData.RotationSpeed * Time.fixedDeltaTime);
            stateMachine.Rigidbody.MoveRotation(targetRotation);
        }
    }
}