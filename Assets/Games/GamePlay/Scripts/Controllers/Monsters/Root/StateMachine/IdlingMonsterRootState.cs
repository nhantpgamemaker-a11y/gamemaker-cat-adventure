using GameMaker.Core.Runtime;

namespace Game.GamePlay
{
    public class IdlingMonsterRootState : BaseMonsterRootState
    {
        public override MonsterRootStateType GetStateType()
        {
            return MonsterRootStateType.Idling;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(monsterRootStateMachine.RootMonsterData.RootAnimationData.IdlingAnimationHash);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(monsterRootStateMachine.RootMonsterData.RootAnimationData.IdlingAnimationHash);
        }
    }
}