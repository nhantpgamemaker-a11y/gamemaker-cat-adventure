using GameMaker.Core.Runtime;

namespace CatAdventure.GamePlay
{
    public class CatHardLandingState : CatGroundedState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.HardLanding;
        }

        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.HardLandingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.HardLandingAnimationHash);
        }
    }
}