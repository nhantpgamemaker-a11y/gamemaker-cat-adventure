using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatLoopClimbingState : CatClimbingState
    {
        private Vector3 _startPosition = Vector3.zero;
        public override CatStateType GetStateType()
        {
            return CatStateType.LoopClimbing;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _startPosition = stateMachine.transform.position;
            StartBoolAnimation(stateMachine.CatAnimationData.LoopClimbingAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.LoopClimbingAnimationHash);
            _startPosition = Vector3.zero;
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            var upward = Vector3.up;
            stateMachine.Rigidbody.AddForce(upward *
            stateMachine.CatConfigData.ClimbingLoopForce - GetVerticalVelocity(), ForceMode.VelocityChange);     
            var distance = Vector3.Distance(_startPosition, stateMachine.transform.position);
            if(distance >= stateMachine.CatConfigData.ClimbingMaxDistance)
            {
                stateMachine.ChangeState(CatStateType.DroppingFromWall);
            }    
        }
    }
}
