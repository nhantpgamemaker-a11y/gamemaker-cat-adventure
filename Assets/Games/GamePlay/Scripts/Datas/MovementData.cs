using UnityEngine;

namespace Game.GamePlay
{
    [System.Serializable]
    public class MovementData
    {
        [SerializeField]
        private float _baseSpeed = 0.5f;
        [SerializeField]
        private float _runningSpeedModifier = 20f;
         [SerializeField]
        private float _airborneSpeedModifier = 1.2f;
        [SerializeField]

        private float _heightCorrectionForce = 20f;
         [SerializeField]
        private float _maxHeightCorrectionForce = 1.2f;
        [SerializeField]

        private float _jumpHeight = 0.3f;
         [SerializeField]

        private float _floatCorrectionStrength = 10f;
        [SerializeField] float _gravityForce = -9.81f;
        public float BaseSpeed { get => _baseSpeed; set => _baseSpeed = value; }
        public float RunningSpeedModifier { get => _runningSpeedModifier; set => _runningSpeedModifier = value; }
        public float AirborneSpeedModifier { get => _airborneSpeedModifier; set => _airborneSpeedModifier = value; }
        public float JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }
        public float HeightCorrectionForce { get => _heightCorrectionForce; }
        public float MaxHeightCorrectionForce { get => _maxHeightCorrectionForce; }
        public float GravityForce { get => _gravityForce; }
        public float FloatCorrectionStrength { get => _floatCorrectionStrength; }
    }
}