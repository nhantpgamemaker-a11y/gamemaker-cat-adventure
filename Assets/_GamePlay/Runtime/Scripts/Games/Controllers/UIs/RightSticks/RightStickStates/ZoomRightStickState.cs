using GameMaker.Core.Runtime;
using UnityEngine.EventSystems;

namespace CatAdventure.GamePlay
{
    public class ZoomRightStickState : BaseRightStickState
    {
        public override RightStickStateType GetStateType()
        {
            return RightStickStateType.Zoom;
        }

        public override void OnEnterState(BaseStateData baseStateData = null)
        {
            base.OnEnterState(baseStateData);
        }

        public override void OnPointerDownHandle(PointerEventData[] pointers, int pointerCount)
        {
            base.OnPointerDownHandle(pointers, pointerCount);
            if (pointerCount == 1)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Pan);
            }
            else if (pointerCount == 0)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Empty);
            }
        }
        public override void OnDragHandle(PointerEventData[] pointers, int pointerCount)
        {
            base.OnDragHandle(pointers, pointerCount);
        }
        public override void OnPointerUpHandle(PointerEventData[] pointers, int pointerCount)
        {
            base.OnPointerUpHandle(pointers, pointerCount);
            if (pointerCount == 1)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Pan);
            }
            else if (pointerCount == 0)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Empty);
            }
        }
    }
}