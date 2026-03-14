using GameMaker.Core.Runtime;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    public class CatIdlingState : CatMovingState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.Idling;
        }
        override public void OnEnterState(BaseStateData baseStateData = null)
        {
            ResetVelocity();
            StartBoolAnimation(stateMachine.CatAnimationData.IdlingAnimationHash);
            base.OnEnterState(baseStateData);
        }

        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.IdlingAnimationHash);
        }
        protected override void OnMoveStated(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(CatStateType.Walking);
        }
    }
}