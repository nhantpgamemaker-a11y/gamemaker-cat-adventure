using GameMaker.Core.Runtime;

namespace CatAdventure.GamePlay
{
    public class CatWalkingState : CatMovingLocalMotionState
    {
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            stateMachine.CatReusableData.CurrentSpeedModifier = stateMachine.CatConfigData.WalkSpeed;
            StartBoolAnimation(stateMachine.CatAnimationData.WalkingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.WalkingAnimationHash);
        }
        public override CatStateType GetStateType()
        {
            return CatStateType.Walking;
        }
    }
}