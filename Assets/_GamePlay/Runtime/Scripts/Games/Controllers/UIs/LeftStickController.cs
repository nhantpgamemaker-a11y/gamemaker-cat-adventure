using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CatAdventure.GamePlay
{
    [RequireComponent(typeof(RectTransform))]
    public class LeftStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RectTransform _defaultTransform;
        [SerializeField] private RectTransform _handleTransform;
        [SerializeField] private RectTransform _pressRectTransform;
        [SerializeField] private RectTransform _safeAreaTransform;
        [SerializeField] private float _maxDragDistance = 100f;

        private int _pointerId = -1;
        private Vector2 _localPoint;
        private Vector2 _pointerDownPosition;
        private Gamepad _virtualGamepad;
        void Start()
        {
            _virtualGamepad = InputSystem.AddDevice<Gamepad>();
            _handleTransform.gameObject.SetActive(false);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_pointerId != -1) return;
            
            _pointerId = eventData.pointerId;
            _handleTransform.gameObject.SetActive(true);
            var parentRect = _handleTransform.parent.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            eventData.position,
            eventData.enterEventCamera,
            out _localPoint
            );
            _handleTransform.localPosition = _localPoint;
            _pointerDownPosition = _localPoint;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (_pointerId != eventData.pointerId) return;
            var point = eventData.position;
            var direction = point - _pointerDownPosition;
            direction.Normalize();
            
            var distance = Vector2.Distance(point, _pointerDownPosition);
            distance = Mathf.Min(distance, _maxDragDistance);
            var parentRect = _pressRectTransform.parent.GetComponent<RectTransform>();
            var newPosition = _pointerDownPosition + direction * distance;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            newPosition,
            eventData.enterEventCamera,
            out Vector2 anchoredPosition
            );
            _pressRectTransform.anchoredPosition = anchoredPosition;

            InputSystem.QueueDeltaStateEvent(_virtualGamepad.leftStick, direction);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_pointerId != eventData.pointerId) return;
            _handleTransform.gameObject.SetActive(false);
            _pressRectTransform.anchoredPosition = Vector2.zero;
            InputSystem.QueueDeltaStateEvent(_virtualGamepad.leftStick, Vector2.zero);
            _pointerId = -1;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_defaultTransform.position, _maxDragDistance);
            Gizmos.color = Color.green;
        }
    }
}
