using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatSneakingState : CatGroundedState
    {
        private bool _lastHeadColliderState = false;
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _lastHeadColliderState = stateMachine.HeadCollider.enabled;
            stateMachine.HeadCollider.enabled = false;
            StartBoolAnimation(stateMachine.CatAnimationData.SneakingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            stateMachine.HeadCollider.enabled = _lastHeadColliderState;
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.SneakingAnimationHash);
        }
    }
}
