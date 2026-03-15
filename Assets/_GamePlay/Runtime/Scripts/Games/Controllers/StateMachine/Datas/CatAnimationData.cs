using UnityEngine;

namespace CatAdventure.GamePlay
{
    [System.Serializable]
    public class CatAnimationData
    {
        // Animator parameter names (editable in Inspector)
        [Header("Animator Parameter Names")]
        [SerializeField] private string _groundedAnimationName = "Grounded";
        [SerializeField] private string _airborneAnimationName = "Airborne";
        [SerializeField] private string _idlingAnimationName = "Idling";
        [SerializeField] private string _movingAnimationName = "Moving";
        [SerializeField] private string _landingAnimationName = "Landing";
        [SerializeField] private string _lightLandingAnimationName = "LightLanding";
        [SerializeField] private string _hardLandingAnimationName = "HardLanding";
        [SerializeField] private string _sneakingAnimationName = "Sneaking";
        [SerializeField] private string _walkingAnimationName = "Walking";
        [SerializeField] private string _runningAnimationName = "Running";
        [SerializeField] private string _jumpingAnimationName = "Jumping";
        [SerializeField] private string _jumpUpAnimationName = "JumpUp";
        [SerializeField] private string _loopJumpingAnimationName = "LoopJumping";
        [SerializeField] private string _jumpDownAnimationName = "JumpDown";
        [SerializeField] private string _forwardSpeedAnimationName = "ForwardSpeed";
        [SerializeField] private string _fallingAnimationName = "Falling";
        [SerializeField] private string _climbingAnimationName = "Climbing";
        [SerializeField] private string _droppingAnimationName = "Dropping";
        [SerializeField] private string _startClimbingAnimationName = "StartClimbing";
        [SerializeField] private string _loopClimbingAnimationName = "LoopClimbing";
        [SerializeField] private string _ledgeClimbingAnimationName = "LedgeClimbing";
        [SerializeField] private string _sneakLocalMotionAnimationName = "SneakLocalMotion";
        [SerializeField] private string _sneakIdlingAnimationName = "SneakIdling";
        [SerializeField] private string _sneakForwardAnimationName = "SneakForward";
        [SerializeField] private string _sneakBackwardAnimationName = "SneakBackward";
        [SerializeField] private string _movingLocalMotionAnimationName = "MovingLocalMotion";
        [SerializeField] private string _targetForwardAngleAnimationName = "TargetForwardAngle";

        // Cached hashes for faster runtime access
        public int GroundedAnimationHash { get; private set; }
        public int AirborneAnimationHash { get; private set; }
        public int IdlingAnimationHash { get; private set; }
        public int MovingAnimationHash { get; private set; }
        public int LandingAnimationHash { get; private set; }
        public int LightLandingAnimationHash { get; private set; }
        public int HardLandingAnimationHash { get; private set; }
        public int SneakingAnimationHash { get; private set; }
        public int WalkingAnimationHash { get; private set; }
        public int RunningAnimationHash { get; private set; }
        public int JumpingAnimationHash { get; private set; }
        public int JumpUpAnimationHash { get; private set; }
        public int LoopJumpingAnimationHash { get; private set; }
        public int JumpDownAnimationHash { get; private set; }
        public int ForwardSpeedAnimationHash { get; private set; }
        public int FallingAnimationHash { get; private set; }
        public int ClimbingAnimationHash { get; private set; }
        public int DroppingAnimationHash { get; private set; }
        public int StartClimbingAnimationHash { get; private set; }
        public int LoopClimbingAnimationHash { get; private set; }
        public int LedgeClimbingAnimationHash { get; private set; }
        public int SneakLocalMotionAnimationHash { get; private set; }
        public int SneakIdlingAnimationHash { get; private set; }
        public int SneakBackwardAnimationHash { get; private set; }
        public int MovingLocalMotionAnimationHash { get; private set; }
        public int TargetForwardAngleAnimationHash { get; private set; }
        public int SneakForwardAnimationHash {get; private set;  }
        public void OnInit()
        {
            GroundedAnimationHash = Animator.StringToHash(_groundedAnimationName);
            AirborneAnimationHash = Animator.StringToHash(_airborneAnimationName);
            IdlingAnimationHash = Animator.StringToHash(_idlingAnimationName);
            MovingAnimationHash = Animator.StringToHash(_movingAnimationName);
            LandingAnimationHash = Animator.StringToHash(_landingAnimationName);
            LightLandingAnimationHash = Animator.StringToHash(_lightLandingAnimationName);
            HardLandingAnimationHash = Animator.StringToHash(_hardLandingAnimationName);
            SneakingAnimationHash = Animator.StringToHash(_sneakingAnimationName);
            WalkingAnimationHash = Animator.StringToHash(_walkingAnimationName);
            RunningAnimationHash = Animator.StringToHash(_runningAnimationName);
            JumpingAnimationHash = Animator.StringToHash(_jumpingAnimationName);
            JumpUpAnimationHash = Animator.StringToHash(_jumpUpAnimationName);
            LoopJumpingAnimationHash = Animator.StringToHash(_loopJumpingAnimationName);
            JumpDownAnimationHash = Animator.StringToHash(_jumpDownAnimationName);
            ForwardSpeedAnimationHash = Animator.StringToHash(_forwardSpeedAnimationName);
            FallingAnimationHash = Animator.StringToHash(_fallingAnimationName);
            ClimbingAnimationHash = Animator.StringToHash(_climbingAnimationName);
            DroppingAnimationHash = Animator.StringToHash(_droppingAnimationName);
            StartClimbingAnimationHash = Animator.StringToHash(_startClimbingAnimationName);
            LoopClimbingAnimationHash = Animator.StringToHash(_loopClimbingAnimationName);
            LedgeClimbingAnimationHash = Animator.StringToHash(_ledgeClimbingAnimationName);
            SneakLocalMotionAnimationHash = Animator.StringToHash(_sneakLocalMotionAnimationName);
            SneakIdlingAnimationHash = Animator.StringToHash(_sneakIdlingAnimationName);
            SneakForwardAnimationHash = Animator.StringToHash(_sneakForwardAnimationName);
            SneakBackwardAnimationHash = Animator.StringToHash(_sneakBackwardAnimationName);
            MovingLocalMotionAnimationHash = Animator.StringToHash(_movingLocalMotionAnimationName);
            TargetForwardAngleAnimationHash = Animator.StringToHash(_targetForwardAngleAnimationName);
        }
    }
}
