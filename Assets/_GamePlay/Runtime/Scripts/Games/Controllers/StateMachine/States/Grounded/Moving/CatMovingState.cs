using GameMaker.Core.Runtime;

namespace CatAdventure.GamePlay
{
    public abstract class CatMovingState: CatGroundedState
    {
        override public void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.MovingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.MovingAnimationHash);
        }
    }
}