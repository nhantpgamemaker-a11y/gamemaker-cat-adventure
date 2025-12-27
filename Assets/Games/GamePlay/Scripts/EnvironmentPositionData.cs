using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class EnvironmentPositionData : TransformReferenceData
    {
        [UnityEngine.SerializeField]
        private float _layerIndex;

        public EnvironmentPositionData(Vector2 position,
        Vector3 scale,
        string referenceID,
        float layerIndex) : base(position,scale, referenceID)
        {
            _layerIndex = layerIndex;
        }

        public float LayerIndex { get => _layerIndex; set => _layerIndex = value; }
    }
}