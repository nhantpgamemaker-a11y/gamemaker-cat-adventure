using System.Collections.Generic;
using GameMaker.Core.Runtime;

namespace GameMaker.Item.Runtime
{
    [System.Serializable]
    public class ItemStatDefinition : BaseDefinition
    {
        [UnityEngine.SerializeField]
        private float _defaultValue;
        public float DefaultValue { get => _defaultValue; set => _defaultValue = value; }
    }
}