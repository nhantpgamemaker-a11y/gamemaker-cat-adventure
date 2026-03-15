using System;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class BaseCatState :MonoBehaviour, IState<CatStateType>
    {
        protected CatStateMachine stateMachine;
        public abstract CatStateType GetStateType();
        public virtual void OnEnterState(BaseStateData baseStateData = null)
        {
            GameMaker.Core.Runtime.Logger.Log($"Entering state {GetStateType()}");
            RegisterInputActions();
        }

        

        public virtual void OnExitState()
        {
            GameMaker.Core.Runtime.Logger.Log($"Exiting state {GetStateType()}");
            UnRegisterInputActions();
        }
       

        public void SetStateMachine(CatStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void OnFixedUpdate()
        {
           
        }

        public virtual void OnUpdate()
        {
            ReadPlayerInput();
        }

        private void ReadPlayerInput()
        {
            var moveInput = stateMachine.CatInputAction.Cat.Move.ReadValue<Vector2>();
            stateMachine.CatReusableData.CurrentMoveInput = moveInput;
        }

        protected virtual void RegisterInputActions()
        {
            
        }
        protected virtual void UnRegisterInputActions()
        {
            
        }
        protected void StartBoolAnimation(int animationHash)
        {
            stateMachine.StartBoolAnimation(animationHash);
        }
        protected void StopBoolAnimation(int animationHash)
        {
            stateMachine.StopBoolAnimation(animationHash);
        }
        protected void SetFloatAnimation(int animationHash, float value)
        {
            stateMachine.SetFloatAnimation(animationHash, value);
        }

        protected Vector3 GetVelocity()
        {
            return stateMachine.Rigidbody.linearVelocity;
        }
        protected Vector3 GetVerticalVelocity()
        {
            var velocity = stateMachine.Rigidbody.linearVelocity;
            velocity.x = 0f;
            velocity.z = 0f;
            return velocity;
        }
        protected Vector3 GetHorizontalVelocity()
        {
            var velocity = stateMachine.Rigidbody.linearVelocity;
            velocity.y = 0f;
            return velocity;
        }
        public Vector3 GetForwardDirection()
        {
            var moveInput = stateMachine.CatReusableData.CurrentMoveInput;
            if (moveInput == Vector2.zero) return stateMachine.transform.forward;
            var cameraTransform = Camera.main.transform;

            var forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            var right = cameraTransform.right;
            right.y = 0;
            right.Normalize();

            var moveDirection = forward * moveInput.y + right * moveInput.x;
            if (moveDirection.sqrMagnitude <= 0.0001f) return stateMachine.transform.forward;
            moveDirection.Normalize();
            return moveDirection;
        }
        
        protected void ResetVelocity()
        {
            stateMachine.Rigidbody.linearVelocity = Vector3.zero;
        }

        protected internal virtual void OnAnimationStartEvent()
        {
            
        }

        protected internal virtual void OnAnimationTransitionEvent()
        {
            
        }

        protected internal virtual void OnAnimationEndEvent()
        {
           
        }
    }   
}