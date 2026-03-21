using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatJumpingUpState : CatJumpingState
    {
        private Vector3 _positionEnter;
        private bool _canAddForce = false;
        public override CatStateType GetStateType()
        {
            return CatStateType.JumpingUp;
        }
        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            _positionEnter = stateMachine.transform.position;
            _canAddForce = false;
            StartBoolAnimation(stateMachine.CatAnimationData.JumpUpAnimationHash);
            base.OnEnterState(baseStateData);
        }
        public override void OnExitState()
        {
            base.OnExitState();
            StopBoolAnimation(stateMachine.CatAnimationData.JumpUpAnimationHash);
        }
        public override void OnFixedUpdate()
        {
            if (_canAddForce)
            {   
                base.OnFixedUpdate();
                var currentVerticalVelocity = GetVerticalVelocity();
                var targetVerticalVelocity = new Vector3(0, stateMachine.CatConfigData.JumpUpForce, 0) - currentVerticalVelocity;
                stateMachine.Rigidbody.AddForce(targetVerticalVelocity, ForceMode.VelocityChange);
                var distance = Vector3.Distance(_positionEnter, stateMachine.transform.position);
                if (distance >= stateMachine.CatConfigData.JumpDistance)
                {
                    stateMachine.ChangeState(CatStateType.Falling);
                }
            }
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            
        }
        protected internal override void OnAnimationStartEvent()
        {
            base.OnAnimationStartEvent();
            _canAddForce = true;
        }
    }
}