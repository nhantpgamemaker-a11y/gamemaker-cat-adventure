using System;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public abstract class BasePlayerState : MonoBehaviour, IState<PlayerStateType>
    {
        protected PlayerStateMachine playerStateMachine;
        public abstract PlayerStateType GetStateType();

        private Vector2 _lastDirection = Vector2.zero;
        public virtual void OnEnterState(BaseStateData baseStateData = null)
        {

        }

        public virtual void OnExitState()
        {
        }

        public virtual void OnPhysicUpdate()
        {

        }

        public virtual void OnUpdate()
        {
            var direction = playerStateMachine.PlayerReusableData.GetControlDirection();
            if(_lastDirection.x != direction.x && direction.x!=0)
            {
                direction.x = direction.x<0 ? -1 : 1;
                playerStateMachine.SetFloatAnimation(
                    playerStateMachine.PlayerData.AnimationData.DirectionAnimationHash,
                    direction.x);
                _lastDirection = direction;
            }
        }

        public void SetStateMachine(IStateMachine<PlayerStateType> stateMachine)
        {
            playerStateMachine = stateMachine as PlayerStateMachine;
        }
        public void SetFloatAnimation(int hashId, float value)
        {
            playerStateMachine.SetFloatAnimation(hashId, value);
        }
        public void StartAnimation(int hashId)
        {
            playerStateMachine.StartAnimation(hashId);
        }
        public void StopAnimation(int hashId)
        {
            playerStateMachine.StopAnimation(hashId);
        }
        public void ResetVelocity()
        {
            playerStateMachine.Rigidbody.linearVelocity = Vector2.zero;
        }
        public void ResetHorizontalVelocity()
        {
            playerStateMachine.Rigidbody.linearVelocityX = 0f;
        }
        public void ResetVerticalVelocity()
        {
            playerStateMachine.Rigidbody.linearVelocityY = 0f;
        }
        public Vector2 GetHorizontalVelocity()
        {
            var velocity = playerStateMachine.Rigidbody.linearVelocity;
            velocity.y = 0f;
            return velocity;
        }
        public Vector2 GetVerticalVelocity()
        {
             var velocity = playerStateMachine.Rigidbody.linearVelocity;
            velocity.x = 0f;
            return velocity;
        }

        internal virtual void OnAnimationStartEventHandle()
        {
           
        }

        internal virtual void OnAnimationTransitionEventHandle()
        {
            
        }

        internal virtual void OnAnimationEndEventHandle()
        {
        }
    }
}