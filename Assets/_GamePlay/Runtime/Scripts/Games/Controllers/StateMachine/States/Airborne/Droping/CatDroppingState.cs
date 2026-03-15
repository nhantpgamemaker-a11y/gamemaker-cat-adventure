using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public abstract class CatDroppingState : CatAirborneState
    {
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            StartBoolAnimation(stateMachine.CatAnimationData.DroppingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.DroppingAnimationHash);
        }
    }
}
