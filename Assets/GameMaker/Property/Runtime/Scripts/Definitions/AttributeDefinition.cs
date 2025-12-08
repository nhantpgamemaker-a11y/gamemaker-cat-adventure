using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class AttributeDefinition : PropertyDefinition
    {
        [SerializeField]
        private string _defaultValue;
        public string DefaultValue { get => _defaultValue; set => _defaultValue = value; }
        public AttributeDefinition() : base()
        {
            
        }
        public AttributeDefinition(string id, string name, string title, string defaultValue) : base(id, name, title)
        {
            DefaultValue = defaultValue;
        }
        public override object Clone()
        {
            return new AttributeDefinition(id, name, title, DefaultValue);
        }
    }
}