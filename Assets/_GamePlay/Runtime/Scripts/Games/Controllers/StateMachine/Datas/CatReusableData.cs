using UnityEngine;

namespace CatAdventure.GamePlay
{
    [System.Serializable]
    public class CatReusableData
    {
        [UnityEngine.SerializeField]
        private float _currentSpeedModifier;
        [UnityEngine.SerializeField]
        private Vector2 _currentMoveInput;
        [UnityEngine.SerializeField]
        private float _currentForwardAngle;

        [UnityEngine.SerializeField]
        private float _currentForwardAngleVelocity;

        [UnityEngine.SerializeField]
        private float _targetForwardAngle;
        public float CurrentSpeedModifier
        {
            get => _currentSpeedModifier;
            set => _currentSpeedModifier = value;
        }
        public Vector2 CurrentMoveInput
        {
            get => _currentMoveInput;
            set => _currentMoveInput = value;
        }
        public float TargetForwardAngle
        {
            get => _targetForwardAngle;
            set => _targetForwardAngle = value;
        }
        public float CurrentForwardAngle
        {
            get => _currentForwardAngle;
            set => _currentForwardAngle = value;
        }
        public float CurrentForwardAngleVelocity
        {
            get => _currentForwardAngleVelocity;
            set => _currentForwardAngleVelocity = value;
        }
    }
}
