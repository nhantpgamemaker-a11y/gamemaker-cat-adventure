
using UnityEngine.EventSystems;

namespace CatAdventure.GamePlay
{
    public interface ITouchStrategy
    {
        void OnPointerDown(PointerEventData[] pointers, int pointerCount);
        void OnDrag(PointerEventData[] pointers, int pointerCount);
        void OnPointerUp(PointerEventData[] pointers, int pointerCount);
    }
}