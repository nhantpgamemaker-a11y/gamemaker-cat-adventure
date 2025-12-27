using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class MonsterPositionData : TransformReferenceData
    {
        public MonsterPositionData(Vector2 position,Vector3 scale, string referenceID) : base(position,scale, referenceID)
        {
        }
    }
}