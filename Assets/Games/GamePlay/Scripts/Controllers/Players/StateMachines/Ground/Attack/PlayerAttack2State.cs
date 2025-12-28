using GameMaker.Core.Runtime;

namespace Game.GamePlay
{
    public  class PlayerAttack2State : PlayerAttackState
    {
        
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
            StartAnimation(playerStateMachine.PlayerData.AnimationData.Attack2AnimationHash);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopAnimation(playerStateMachine.PlayerData.AnimationData.Attack2AnimationHash);
        }
        public override void NextAttack()
        {
            playerStateMachine.ChangeState(PlayerStateType.Attacking_3);
        }

        public override PlayerStateType GetStateType()
        {
            return PlayerStateType.Attacking_2;
        }
    }
}