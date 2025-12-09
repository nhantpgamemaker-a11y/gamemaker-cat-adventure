using System;
using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
    [System.Serializable]
    public class ItemStatDefinitionRef: IDefinition,ICloneable, IEquatable<ItemStatDefinitionRef>
    {
        [SerializeField]
        private string _referenceId;
        [SerializeField]
        private float _value;

        public string ReferenceId { get => _referenceId; set => _referenceId = value; }
        public float Value { get => _value; set => _value = value; }
        public ItemStatDefinitionRef(string refId, float value)
        {
            _referenceId = refId;
            _value = value;
        }

        public string GetID()
        {
            return _referenceId;
        }

        public string GetName()
        {
            return _referenceId;
        }

        public bool Equals(ItemStatDefinitionRef other)
        {
            return other.ReferenceId == _referenceId;
        }

        public object Clone()
        {
            return new ItemStatDefinitionRef(_referenceId, _value);
        }
    }

    [System.Serializable]
    public class ItemDetailDefinition : BaseDefinition
    {
        [SerializeField]
        private string _itemDefinitionId;
        [SerializeField]
        private List<ItemStatDefinitionRef> _itemStatDefinitionRefs = new();
        public IReadOnlyList<ItemStatDefinitionRef> ItemStatDefinitionRefs { get => _itemStatDefinitionRefs; }
        public string ItemDefinitionId => _itemDefinitionId;
        public ItemDetailDefinition(string id, string name, string title,string itemDefinitionId,List<ItemStatDefinitionRef> itemStatDefinitionRefs): base(id, name, title)
        {
            _itemDefinitionId = itemDefinitionId;
            _itemStatDefinitionRefs = itemStatDefinitionRefs;
        }
        public void AddItemStatDefinitionRef(ItemStatDefinitionRef itemStatDefinitionRef)
        {
            _itemStatDefinitionRefs.Add(itemStatDefinitionRef);
        }

        public override object Clone()
        {
            return new ItemDetailDefinition(id, name, title,_itemDefinitionId,_itemStatDefinitionRefs.Select(i=> i.Clone() as ItemStatDefinitionRef).ToList());
        }

        public void RemoveItemStatDefinitionRef(ItemStatDefinitionRef itemStatDefinitionRef)
        {
            _itemStatDefinitionRefs.Remove(itemStatDefinitionRef);
        }
    }
}