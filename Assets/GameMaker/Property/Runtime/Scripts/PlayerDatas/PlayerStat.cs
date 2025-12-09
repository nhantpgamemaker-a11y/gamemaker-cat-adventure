using System;
using GameMaker.Core.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class PlayerStat : PlayerProperty
    {
        private float _value;
        
        public float Value { get => _value; set => _value = value; }

        public PlayerStat(IDefinition definition, float value):base(definition)
        {
            _value = value;
        }

        public override object Clone()
        {
            return new PlayerStat(definition, _value);
        }
        public void AddValue(float value)
        {
            _value += value;
            NotifyObserver(this);
        }
    }
}
