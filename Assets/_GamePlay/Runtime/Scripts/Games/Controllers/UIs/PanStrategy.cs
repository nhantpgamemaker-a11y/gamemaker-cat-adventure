using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    public class PanStrategy : MonoBehaviour, ITouchStrategy
    {
        private Gamepad _virtualGamepad = new Gamepad();
        private int _pointerCount = 0;
        void Start()
        {
            _virtualGamepad = InputSystem.AddDevice<Gamepad>();
        }
        public void OnPointerDown(PointerEventData[] pointers, int pointerCount)
        {
            _pointerCount = pointerCount;
        }
        public void OnDrag(PointerEventData[] pointers, int pointerCount)
        {
            _pointerCount = pointerCount;
            if(_pointerCount == 1)
            {
                Vector2 delta = pointers[0].delta;
                InputSystem.QueueDeltaStateEvent(_virtualGamepad.rightStick, delta);
                Debug.Log($"Pan delta: {delta}");
            }
        }

        public void OnPointerUp(PointerEventData[] pointers, int pointerCount)
        {
            _pointerCount = pointerCount;
           InputSystem.QueueDeltaStateEvent(_virtualGamepad.rightStick, Vector2.zero);
        }
    }
}