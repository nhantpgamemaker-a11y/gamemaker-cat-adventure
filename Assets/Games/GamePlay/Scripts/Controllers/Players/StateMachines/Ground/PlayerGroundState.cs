using System;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.GamePlay
{
    public abstract class PlayerGroundState : BasePlayerState
    {
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.GroundAnimationHash);
            RegisterInputAction();
        }



        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.GroundAnimationHash);
            UnRegisterInputAction();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
        }
        public override void OnPhysicUpdate()
        {
            base.OnPhysicUpdate();
            FloatingHandle();
            GroundHandle();
        }

        protected virtual void RegisterInputAction()
        {
            playerStateMachine.PlayerInputAction.Player.Move.started += OnMoveStarted;
            playerStateMachine.PlayerInputAction.Player.Jump.performed += OnJumpPerformed;
            playerStateMachine.PlayerInputAction.Player.Attack.started += OnAttackStated;
        }

        private void OnAttackStated(InputAction.CallbackContext context)
        {
            playerStateMachine.ChangeState(PlayerStateType.Attacking_1);
        }

        protected virtual void UnRegisterInputAction()
        {
            playerStateMachine.PlayerInputAction.Player.Move.started -= OnMoveStarted;
            playerStateMachine.PlayerInputAction.Player.Jump.performed -= OnJumpPerformed;
            playerStateMachine.PlayerInputAction.Player.Attack.started -= OnAttackStated;
        }

        protected void OnJumpPerformed(InputAction.CallbackContext context)
        {
            playerStateMachine.ChangeState(PlayerStateType.Jumping);
        }

        private void OnMoveStarted(InputAction.CallbackContext context)
        {
            playerStateMachine.ChangeState(PlayerStateType.Running);
        }
        private void FloatingHandle()
        {
            var centerPoint = playerStateMachine.GetCenterBody();
            var bottomPoint = playerStateMachine.GetMinPoint();
            var direction = bottomPoint - centerPoint;
            var hit = Physics2D.CircleCast(
                centerPoint,
                0.01f,
                direction,
                direction.magnitude + 0.1f,
                playerStateMachine.PlayerData.LayerData.GroundLayer
            );
            if (!hit)
            {
                return;
            }
            float currentDistance = hit.distance;
            float targetDistance = direction.magnitude;
            float distanceDifference = currentDistance - targetDistance;
            if (Mathf.Abs(distanceDifference) > 0.01f)
            {
                Vector2 velocity = playerStateMachine.Rigidbody.linearVelocity;
                
               
                float correctionSpeed = distanceDifference * playerStateMachine.PlayerData.MovementData.FloatCorrectionStrength;
                velocity.y = -correctionSpeed;
                
                playerStateMachine.Rigidbody.linearVelocity = velocity;
            }
            else
            {
                Vector2 velocity = playerStateMachine.Rigidbody.linearVelocity;
                velocity.y = 0f;
                playerStateMachine.Rigidbody.linearVelocity = velocity;
            }
        }
        private void GroundHandle()
        {
            var centerPoint = playerStateMachine.GetCenterBody();
            var bottomPoint = playerStateMachine.GetMinPoint();
            var direction = bottomPoint - centerPoint;
            var size = playerStateMachine.GroundCheckCollider.bounds.size;
            size.y = size.x;
            var hit = Physics2D.BoxCast(centerPoint, size,0, direction, direction.magnitude - size.x/2f, playerStateMachine.PlayerData.LayerData.GroundLayer);
            if (!hit)
            {
                playerStateMachine.ChangeState(PlayerStateType.Falling);
            }
        }
    }
}
    