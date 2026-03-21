using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatFallingState : CatAirborneState
    {
        public override CatStateType GetStateType()
        {
            return CatStateType.Falling;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.FallingAnimationHash);
            base.OnEnterState(baseStateData);
            ResetVelocity();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.FallingAnimationHash);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if(IsGrounded())
            {
                stateMachine.ChangeState(CatStateType.LightLanding);
                return;
            }
        }
    }
}
