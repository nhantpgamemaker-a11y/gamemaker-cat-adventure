using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public enum CatStateType
    {
        Idling,
        Walking,
        Running,
        Jumping,
        Falling,
        SneakIdling,
        Sneaking,
        SneakForward,
        SneakBackward,
        LightLanding,
        HardLanding,
        DroppingFromEdge
    }

    public class CatStateMachine : MonoBehaviour, IStateMachine<CatStateType>
    {
        [SerializeField]
        private CatStateType _defaultStateType;
        [Header("Data")]
        [SerializeField] private CatConfigData _catConfigData;
        [SerializeField] private CatReusableData _catReusableData;
        [SerializeField] private CatAnimationData _catAnimationData;
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _hearCollider;
        [SerializeField] private Collider[] _bodyColliders;
        [SerializeField] private BoxCollider _groundCheckCollider;
        [SerializeField] private BoxCollider _sneakCheckCollider;
        [SerializeField] private BoxCollider _droppingCheckCollider;   

        private Dictionary<CatStateType, BaseCatState> _stateLookup;
        private CatStateType _currentStateType;
        private BaseCatState _currentState;
        private CatInputAction _catInputAction;

        public CatConfigData CatConfigData => _catConfigData;
        public CatReusableData CatReusableData => _catReusableData;
        public CatAnimationData CatAnimationData => _catAnimationData;
        public CatInputAction CatInputAction => _catInputAction;
        public Rigidbody Rigidbody => _rigidbody;
        public BoxCollider GroundCheckCollider => _groundCheckCollider;
        public BoxCollider SneakCheckCollider => _sneakCheckCollider;
        public BoxCollider DropCheckCollider => _droppingCheckCollider;
        public Collider[] BodyColliders => _bodyColliders;
        public Collider HeadCollider => _hearCollider;
        public void ChangeState(CatStateType stateType, BaseStateData baseStateData = null)
        {
            _currentState?.OnExitState();
            _currentStateType = stateType;
            _currentState = _stateLookup[_currentStateType];
            _currentState?.OnEnterState(baseStateData);
        }

        public void OnInit(List<IState<CatStateType>> states)
        {
            _stateLookup = new();
            _catInputAction = new CatInputAction();
            _catInputAction.Enable();
            foreach (var state in states)
            {
                var baseCatState = state as BaseCatState;
                baseCatState.SetStateMachine(this);
                _stateLookup[baseCatState.GetStateType()] = baseCatState;
            }
            _catAnimationData.OnInit();
            ChangeState(_defaultStateType);
        }

        
        public void OnUpdate()
        {
            _currentState?.OnUpdate();
        }
        
        public void OnFixedUpdate()
        {
            _currentState?.OnFixedUpdate();
        }

        public void StartBoolAnimation(int animationHash)
        {
            _animator.SetBool(animationHash, true);
        }

        public void StopBoolAnimation(int animationHash)
        {
            _animator.SetBool(animationHash, false);
        }

        public void SetFloatAnimation(int animationHash, float value)
        {
            _animator.SetFloat(animationHash, value);
        }

        Dictionary<CatStateType, IState<CatStateType>> IStateMachine<CatStateType>.GetStatesLookup()
        {
            var lookup = new Dictionary<CatStateType, IState<CatStateType>>();
            foreach (var kvp in _stateLookup)
            {
                lookup[kvp.Key] = kvp.Value as IState<CatStateType>;
            }
            return lookup;
        }

        CatStateType IStateMachine<CatStateType>.GetCurrentStateType()
        {
            return _currentStateType;
        }

        IState<CatStateType> IStateMachine<CatStateType>.GetCurrentState()
        {
            return _currentState;
        }

        internal void OnAnimationStartEvent()
        {
            _currentState?.OnAnimationStartEvent();
        }

        internal void OnAnimationTransitionEvent()
        {
            _currentState?.OnAnimationTransitionEvent();
        }

        internal void OnAnimationEndEvent()
        {
            _currentState?.OnAnimationEndEvent();
        }
    }
}
