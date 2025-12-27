using Codice.Utils;
using UnityEngine;

namespace Game.GamePlay
{
    [System.Serializable]
    public class AnimationData
    {
        [SerializeField]
        private string _idlingAnimationName = "Idling";
        [SerializeField]
        private string _runningAnimationName = "Running";
        [SerializeField]
        private string _jumpingAnimationName = "Jumping";
        [SerializeField]
        private string _fallingAnimationName = "Falling";
        [SerializeField]
        private string _groundAnimationName = "Ground";
        [SerializeField]
        private string _airborneAnimationName = "Airborne";
        [SerializeField]
        private string _landingAnimationName = "Landing";
        [SerializeField]
        private string _moveAnimationName = "Move";
        [SerializeField]
        private string _directionAnimationName = "Direction";

        public int IdlingAnimationHash { get; private set; }
        public int RunningAnimationHash { get; private set; }
        public int JumpingAnimationHash { get; private set; }
        public int FallingAnimationHash { get; private set; }
        public int GroundAnimationHash { get; private set; }
        public int AirborneAnimationHash { get; private set; }
        public int LandingAnimationHash { get; private set; }
        public int MoveAnimationHash { get; private set; }
        public int DirectionAnimationHash { get; private set; }

        public void OnInit()
        {
            IdlingAnimationHash = Animator.StringToHash(_idlingAnimationName);
            RunningAnimationHash = Animator.StringToHash(_runningAnimationName);
            JumpingAnimationHash = Animator.StringToHash(_jumpingAnimationName);
            FallingAnimationHash = Animator.StringToHash(_fallingAnimationName);
            GroundAnimationHash = Animator.StringToHash(_groundAnimationName);
            AirborneAnimationHash = Animator.StringToHash(_airborneAnimationName);
            LandingAnimationHash = Animator.StringToHash(_landingAnimationName);
            MoveAnimationHash = Animator.StringToHash(_moveAnimationName);
            DirectionAnimationHash = Animator.StringToHash(_directionAnimationName);
        }
    }
}