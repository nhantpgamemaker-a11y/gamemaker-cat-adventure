using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class TransformData
    {
        [UnityEngine.SerializeField]
        private Vector2 _position;
        [UnityEngine.SerializeField]
        private Vector3 _scale;
        public Vector2 Position { get => _position; set => _position = value; }
        public Vector3 Scale { get => _scale; set => _scale = value; }

        public TransformData(Vector2 position, Vector3 scale)
        {
            _position = position;
            _scale = scale;
        }
        
    }
}