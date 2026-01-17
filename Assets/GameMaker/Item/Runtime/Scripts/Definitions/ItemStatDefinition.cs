using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

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
        public ItemStatDefinition(string id, string name, string title,string description, Sprite icon, float defaultValue): base(id, name, title,description, icon)
        {
            _defaultValue = defaultValue;
        }

        public override object Clone()
        {
            return new ItemStatDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), _defaultValue);
        }
    }
}