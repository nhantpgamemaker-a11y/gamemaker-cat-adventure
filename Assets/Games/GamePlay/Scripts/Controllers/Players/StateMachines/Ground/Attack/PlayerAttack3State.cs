using GameMaker.Core.Runtime;

namespace Game.GamePlay
{
    public class PlayerAttack3State : PlayerAttackState
    {
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Attacking_3;
        }

        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.Attack3AnimationHash);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.Attack3AnimationHash);
        }
    }
}