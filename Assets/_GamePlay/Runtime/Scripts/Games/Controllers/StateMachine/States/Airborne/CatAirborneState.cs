using GameMaker.Core.Runtime;

namespace CatAdventure.GamePlay
{
    public abstract class CatAirborneState : BaseCatState
    {
        override public void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.AirborneAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.AirborneAnimationHash);
        }
    }
}