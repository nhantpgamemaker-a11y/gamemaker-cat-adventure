using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class AttributeActionData : PropertyActionData
    {
        private string _value;
        public string Value { get => _value; }
        public AttributeActionData(string propertyId,string value, object data = null) : base(propertyId, data)
        {
            _value = value;
        }
    }
}