using System;
using GameMaker.Core.Runtime;
using Newtonsoft.Json;
using UnityEngine;

namespace GameMaker.Currency.Runtime
{
    [System.Serializable]
    public class PlayerCurrency : BasePlayerData
    {
        private float _value;
        public float Value { get => _value; set => _value = value; }
        public PlayerCurrency(IDefinition definition, float value) : base(definition)
        {
            _value = value;
        }

        public override object Clone()
        {
            return new PlayerCurrency(definition, _value);
        }

        public void AddValue(float amount)
        {
            _value += amount;
            NotifyObserver(this);
        }
    }
}