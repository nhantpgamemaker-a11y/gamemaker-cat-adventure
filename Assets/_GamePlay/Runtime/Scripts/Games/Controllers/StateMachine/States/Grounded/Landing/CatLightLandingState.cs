using GameMaker.Core.Runtime;

namespace CatAdventure.GamePlay
{
    public class CatLightLandingState : CatGroundedState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.LightLanding;
        }

        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.LightLandingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.LightLandingAnimationHash);
        }
    }
}