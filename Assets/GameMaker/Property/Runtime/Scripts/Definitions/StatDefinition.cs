using NUnit.Framework;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class StatDefinition : PropertyDefinition
    {
        [SerializeField] private float _defaultValue;
        public float DefaultValue { get => _defaultValue; set => _defaultValue = value; }
        public StatDefinition(): base()
        {
            
        }
        public StatDefinition(string id, string name, string title, float defaultValue) : base(id, name, title)
        {
            DefaultValue = defaultValue;
        }
        public override object Clone()
        {
            return new StatDefinition(id, name, title, DefaultValue);
        }
    }
}