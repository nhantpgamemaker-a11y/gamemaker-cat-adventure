using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
    [System.Serializable]
    public class ItemStatDefinitionRef: IDefinition, IEquatable<ItemStatDefinitionRef>
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
    }

    [System.Serializable]
    public class ItemDetailDefinition : BaseDefinition
    {
        [SerializeField]
        private List<ItemStatDefinitionRef> _itemStatDefinitionRefs = new();
        public IReadOnlyList<ItemStatDefinitionRef> ItemStatDefinitionRefs { get => _itemStatDefinitionRefs; }
        public void AddItemStatDefinitionRef(ItemStatDefinitionRef itemStatDefinitionRef)
        {
            _itemStatDefinitionRefs.Add(itemStatDefinitionRef);
        }
        public void RemoveItemStatDefinitionRef(ItemStatDefinitionRef itemStatDefinitionRef)
        {
            _itemStatDefinitionRefs.Remove(itemStatDefinitionRef);
        }
    }
}