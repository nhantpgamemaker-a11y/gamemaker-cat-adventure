using GameMaker.Core.Runtime;
using UnityEngine.EventSystems;

namespace CatAdventure.GamePlay
{
    public class EmptyRightStickState : BaseRightStickState
    {
        public override RightStickStateType GetStateType()
        {
            return RightStickStateType.Empty;
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
            else if (pointerCount == 2)
            {
                RightStickStateMachine.ChangeState(RightStickStateType.Zoom);
            }
        }
    }
}