using System;
using GameMaker.Core.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class PlayerAttribute : PlayerProperty
    {
        private string _value;
        public string Value { get => _value; set => _value = value; }

        public PlayerAttribute(IDefinition definition, string value):base(definition)
        {
            _value = value;
        }

        public override object Clone()
        {
            return new PlayerAttribute(definition, _value);
        }
        public void SetValue(string value)
        {
            _value = value;
            NotifyObserver(this);
        }
    }
}
