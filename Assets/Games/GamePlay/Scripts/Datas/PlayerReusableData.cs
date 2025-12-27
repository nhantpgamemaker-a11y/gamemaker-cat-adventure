using System;
using UnityEngine;

namespace Game.GamePlay
{
    [System.Serializable]
    public class PlayerReusableData
    {
        private Vector2 _controlDirection = Vector2.zero;
        private float _speedModifier = 1f;
        public void SetSpeedModifier(float speed)
        {
            _speedModifier = speed;
        }
        public float GetSpeedModifier()
        {
            return _speedModifier;
        }
        public void SetControlDirection(Vector2 controlDirection)
        {
            _controlDirection = controlDirection;
        }
        public Vector2 GetControlDirection()
        {
            return _controlDirection;
        }

        internal void SetSpeedModifier(object airborneSpeedModifier)
        {
            throw new NotImplementedException();
        }
    }
}