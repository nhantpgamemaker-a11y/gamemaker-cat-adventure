using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    public class PanRightStickState : BaseRightStickState
    {
        private int _pointerCount = 0;
        public override RightStickStateType GetStateType()
        {
            return RightStickStateType.Pan;
        }
        public override void OnInit()
        {
            base.OnInit();
        }
        public override void OnExitState()
        {
            base.OnExitState();
            InputSystem.QueueDeltaStateEvent(RightStickStateMachine.VirtualGamepad.rightStick, Vector2.zero);
        }
        public override void OnPointerDownHandle(PointerEventData[] pointers, int pointerCount)
        {
            base.OnPointerDownHandle(pointers, pointerCount);
            _pointerCount = pointerCount;
            if (_pointerCount == 2)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Zoom);
            }
        }
        public override void OnDragHandle(PointerEventData[] pointers, int pointerCount)
        {
            base.OnDragHandle(pointers, pointerCount);
            Vector2 delta = pointers[0].delta;
            InputSystem.QueueDeltaStateEvent(RightStickStateMachine.VirtualGamepad.rightStick, delta);
        }
        public override void OnPointerUpHandle(PointerEventData[] pointers, int pointerCount)
        {
            base.OnPointerUpHandle(pointers, pointerCount);
            _pointerCount = pointerCount;
            if (_pointerCount == 0)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Empty);
            }
            else if (_pointerCount == 2)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Zoom);
            }
        }
    }
}