using GameMaker.Core.Runtime;

namespace CatAdventure.GamePlay
{
    public class CatSneakForwardState : CatSneakLocalMotionState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.SneakForward;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.SneakForwardAnimationHash);
            base.OnEnterState(baseStateData);
        }
        override public void OnExitState()
        {
            StopBoolAnimation(stateMachine.CatAnimationData.SneakForwardAnimationHash);
            base.OnExitState();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!IsForward())
            {
                stateMachine.ChangeState(CatStateType.SneakBackward);
                return;
            }
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }
    }
}