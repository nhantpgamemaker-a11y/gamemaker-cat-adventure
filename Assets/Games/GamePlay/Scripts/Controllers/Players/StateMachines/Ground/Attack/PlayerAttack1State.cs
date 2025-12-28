using GameMaker.Core.Runtime;

namespace Game.GamePlay
{
    public class PlayerAttack1State : PlayerAttackState
    {
        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Attacking_1;
        }

        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.Attack1AnimationHash);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.Attack1AnimationHash);
        }
        public override void NextAttack()
        {
            playerStateMachine.ChangeState(PlayerStateType.Attacking_2);
        }
    }
}