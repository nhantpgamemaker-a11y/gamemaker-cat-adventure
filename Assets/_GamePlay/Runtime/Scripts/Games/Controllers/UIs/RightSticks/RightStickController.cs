using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatAdventure.GamePlay
{
    public class RightStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private List<BaseRightStickState> _states;
        [SerializeField] private RightStickStateMachine _stateMachine;

        private PointerEventData[] _pointers = new PointerEventData[2];
        private int _pointerCount = 0;
        public void Start()
        {
            OnInit();
        }
        public void OnInit()
        {
            _stateMachine.OnInit(_states.ConvertAll(s => s as IState<RightStickStateType>));
            _stateMachine.ChangeState(RightStickStateType.Empty);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _pointers[_pointerCount] = eventData;
            _pointerCount++;
            _stateMachine.OnPointerDownHandle(_pointers, _pointerCount);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdatePointer(eventData);

            _stateMachine.OnDragHandle(_pointers, _pointerCount);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            RemovePointer(eventData);

            _stateMachine.OnPointerUpHandle(_pointers, _pointerCount);
        }

        private void UpdatePointer(PointerEventData eventData)
        {
            for (int i = 0; i < _pointerCount; i++)
            {
                if (_pointers[i].pointerId == eventData.pointerId)
                {
                    _pointers[i] = eventData;
                    break;
                }
            }
        }

        private void RemovePointer(PointerEventData eventData)
        {
            for (int i = 0; i < _pointerCount; i++)
            {
                if (_pointers[i].pointerId == eventData.pointerId)
                {
                    for (int j = i; j < _pointerCount - 1; j++)
                    {
                        _pointers[j] = _pointers[j + 1];
                    }
                    _pointers[_pointerCount - 1] = null;
                    _pointerCount--;
                    break;
                }
            }
        }
    }
}
