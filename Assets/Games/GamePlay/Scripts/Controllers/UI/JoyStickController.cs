using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UIElements;

namespace Game.GamePlay
{
    public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform _joyStickBackground;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer Down on Joystick");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Pointer Up on Joystick");
        }
    }
}
