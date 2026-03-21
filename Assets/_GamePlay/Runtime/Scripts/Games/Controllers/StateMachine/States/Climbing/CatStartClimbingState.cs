
using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatStartClimbingState : CatClimbingState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.StartClimbing;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.StartClimbingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.StartClimbingAnimationHash);
        }
        protected internal override void OnAnimationEndEvent()
        {
            // var forwardDirection = GetForwardDirection();
            // if (stateMachine.CatReusableData.CurrentMoveInput == Vector2.zero)
            // {
            //     stateMachine.ChangeState(CatStateType.DroppingFromWall);
            //     return;
            // }
            // var forward = stateMachine.transform.forward;
            // forward.y = 0;
            // if (Vector2.Dot(forward, forwardDirection) < 0)
            // {
            //     stateMachine.ChangeState(CatStateType.DroppingFromWall);
            //     return;
            // }
            stateMachine.ChangeState(CatStateType.LoopClimbing);
        }
    }
}