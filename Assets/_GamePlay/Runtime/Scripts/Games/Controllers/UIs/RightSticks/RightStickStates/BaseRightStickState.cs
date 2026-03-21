using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatAdventure.GamePlay
{
    public abstract class BaseRightStickState : MonoBehaviour, IState<RightStickStateType>
    {
        private RightStickStateMachine _stateMachine;
        public abstract RightStickStateType GetStateType();

        public RightStickStateMachine RightStickStateMachine => _stateMachine;
        public void SetStateMachine(RightStickStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public virtual void OnInit()
        {

        }
        
        public virtual void OnEnterState(BaseStateData baseStateData = null)
        {
            GameMaker.Core.Runtime.Logger.Log($"Enter {GetStateType()}");
        }

        public virtual void OnExitState()
        {
            GameMaker.Core.Runtime.Logger.Log($"Exit {GetStateType()}");
        }
        public virtual void OnPointerDownHandle(PointerEventData[] pointers, int pointerCount)
        {

        }
        public virtual void OnDragHandle(PointerEventData[] pointers, int pointerCount)
        {

        }
        public virtual void OnPointerUpHandle(PointerEventData[] pointers, int pointerCount)
        {

        }
    }
}