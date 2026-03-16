using UnityEngine;

namespace CatAdventure.GamePlay
{
    [System.Serializable]
    public class CatConfigData
    {
        [SerializeField] [Range(0f, 10f)]private float _walkSpeed = 1f;
        [SerializeField][Range(0f, 10f)] private float _runSpeed = 2f;
        [SerializeField] [Range(0f, 10f)]private float _sneakSpeed = 0.8f;
        [SerializeField] [Range(0f, 360f)]private float _rotationSpeed = 10f;
        [SerializeField][Range(0f, 20f)] private float _gravitySpeed = 9.81f;
        [SerializeField][Range(0f, 0.5f)] private float _speedTransitionSmoothTime = 0.1f;
        [SerializeField][Range(0f, 1f)] private float _animationRotationSmoothTime = 0.2f;
        [SerializeField] private AnimationCurve _speedSlopeModifierByAngle;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _sneakableLayerMask;
        [SerializeField] private LayerMask _droppingLayerMask;
        [SerializeField] private LayerMask _climbableLayerMask;
        [SerializeField] private float _extraGroundedFloatDistance = 0.1f;
        [SerializeField] private float _stepFloatingForce = 5f;
        [SerializeField] private float _sneakForwardMaxAngle = 60f;
        [SerializeField] private float _extraDroppingForce = 5f;

        [SerializeField] private float _extraClimbingGroundFloatDistance = 0.1f;
        [SerializeField] private float _climbingStepFloatingForce = 5f;
        [SerializeField] private float _climbingLoopForce = 5f;
        [SerializeField] private float _climbingMaxDistance = 2f;
        [SerializeField] private float _climbingRotationSpeed = 30f;
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float SneakSpeed => _sneakSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float GravitySpeed => _gravitySpeed;
        public float SpeedTransitionSmoothTime => _speedTransitionSmoothTime;
        public AnimationCurve SpeedSlopeModifierByAngle => _speedSlopeModifierByAngle;
        public float RotationSmoothTime => _animationRotationSmoothTime;
        public LayerMask GroundLayerMask => _groundLayerMask;
        public LayerMask SneakableLayerMask => _sneakableLayerMask;
        public LayerMask DroppingLayerMask => _droppingLayerMask;
        public LayerMask ClimbableLayerMask => _climbableLayerMask;
        public float ExtraGroundedFloatDistance => _extraGroundedFloatDistance;
        public float StepFloatingForce => _stepFloatingForce;
        public float SneakForwardMaxAngle => _sneakForwardMaxAngle;
        public float ExtraDroppingForce => _extraDroppingForce;
        public float ExtraClimbingGroundFloatDistance => _extraClimbingGroundFloatDistance;
        public float ClimbingStepFloatingForce => _climbingStepFloatingForce;
        public float ClimbingMaxDistance => _climbingMaxDistance;
        public float ClimbingRotationSpeed => _climbingRotationSpeed;
        public float ClimbingLoopForce => _climbingLoopForce;
    }
}
