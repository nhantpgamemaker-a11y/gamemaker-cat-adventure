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
        public AttributeDefinition(string id, string name, string title,string description, Sprite icon, string defaultValue) : base(id, name, title,description, icon)
        {
            DefaultValue = defaultValue;
        }
        public override object Clone()
        {
            return new AttributeDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), DefaultValue);
        }
    }
}