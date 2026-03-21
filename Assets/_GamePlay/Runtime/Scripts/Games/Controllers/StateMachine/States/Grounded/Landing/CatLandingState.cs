using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatLandingState : CatGroundedState
    {
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.LandingAnimationHash);
            base.OnEnterState(baseStateData);
            ResetVelocity();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.LandingAnimationHash);
        }
        protected internal override void OnAnimationEndEvent()
        {
            base.OnAnimationEndEvent();
            if(stateMachine.CatReusableData.CurrentMoveInput != Vector2.zero)
            {
                stateMachine.ChangeState(CatStateType.Walking);
                return;
            }
            stateMachine.ChangeState(CatStateType.Idling);
        }
        protected override void RegisterInputActions()
        {
            stateMachine.CatInputAction.Cat.Move.started += OnMoveStated;
        }
        override protected void UnRegisterInputActions()
        {
            stateMachine.CatInputAction.Cat.Move.started -= OnMoveStated;
        }
    }
}
