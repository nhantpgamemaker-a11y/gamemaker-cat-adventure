using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    public class CatSneakIdlingState : CatSneakingState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.SneakIdling;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            ResetVelocity();
            StartBoolAnimation(stateMachine.CatAnimationData.SneakIdlingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            StopBoolAnimation(stateMachine.CatAnimationData.SneakIdlingAnimationHash);
            base.OnExitState();
        }
        protected override void OnMoveStated(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(CatStateType.SneakForward);
        }
    }
}
