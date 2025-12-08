using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
    [System.Serializable]
    public class ItemDefinition : BaseDefinition
    {
        [SerializeField]
        private BaseDefinitionManager<ItemStatDefinition> _itemStatManager = new();

        [UnityEngine.SerializeField]
        private List<ItemDetailDefinition> _itemDetailDefinitions = new();
        public IReadOnlyList<ItemDetailDefinition> ItemDetailDefinitions { get => _itemDetailDefinitions; }
        public void AddItemStat(ItemStatDefinition itemStatDefinition)
        {
            _itemStatManager.AddDefinition(itemStatDefinition);
            foreach(var itemDefinition in ItemDetailDefinitions)
            {
                itemDefinition.AddItemStatDefinitionRef(new ItemStatDefinitionRef(itemStatDefinition.GetID(),itemStatDefinition.DefaultValue));
            }
        }
        public void RemoveItemStat(ItemStatDefinition itemStatDefinition)
        {
            _itemStatManager.RemoveDefinition(itemStatDefinition);
            foreach(var itemDefinition in ItemDetailDefinitions)
            {
                itemDefinition.RemoveItemStatDefinitionRef(new ItemStatDefinitionRef(itemStatDefinition.GetID(),0));
            }
        }
    }
}