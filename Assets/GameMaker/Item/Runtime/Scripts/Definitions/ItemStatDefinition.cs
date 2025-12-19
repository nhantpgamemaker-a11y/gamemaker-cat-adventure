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
        public ItemStatDefinition() : base()
        {
            
        }
        public ItemStatDefinition(string id, string name, string title, float defaultValue): base(id, name, title)
        {
            _defaultValue = defaultValue;
        }

        public override object Clone()
        {
            return new ItemStatDefinition(id, name, title, _defaultValue);
        }
    }
}