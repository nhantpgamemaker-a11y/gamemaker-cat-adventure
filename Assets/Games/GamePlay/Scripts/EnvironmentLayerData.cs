using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class EnvironmentLayerData
    {
        [UnityEngine.SerializeField]
        private Vector3 _scale;
        [UnityEngine.SerializeField]
        private float _zIndex;

        public Vector3 Scale { get => _scale; set => _scale = value; }
        public float ZIndex { get => _zIndex; set => _zIndex = value; }

        public EnvironmentLayerData( Vector3 scale, float zIndex)
        {
            _scale = scale;
            _zIndex = zIndex;
        }
    }
}