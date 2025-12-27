using UnityEngine;
namespace GamePlay
{
    [System.Serializable]
    public class TransformReferenceData : TransformData
    {
        [UnityEngine.SerializeField]
        private string _referenceID;
        public string ReferenceID { get => _referenceID; set => _referenceID = value; }

        public TransformReferenceData(Vector2 position, Vector3 scale, string referenceID) : base(position, scale)
        {
            _referenceID = referenceID;
        }
    }
}