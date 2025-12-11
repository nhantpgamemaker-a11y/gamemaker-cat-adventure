using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
    [System.Serializable]
    public class PlayerDetailItem : BasePlayerData, IDefinition
    {
        private string _id;
        private string _name;
        private List<ItemStatDefinitionRef> _itemStatDefinitionRefs = new();
        public PlayerDetailItem(string id, string name,List<ItemStatDefinitionRef> itemStatDefinitionRefs , IDefinition definition) : base(definition)
        {
            _id = id;
            _name = name;
            _itemStatDefinitionRefs = itemStatDefinitionRefs;
        }

        public List<ItemStatDefinitionRef> ItemStatDefinitionRefs { get => _itemStatDefinitionRefs; }

        public override object Clone()
        {
            return new PlayerDetailItem(_id, _name,_itemStatDefinitionRefs,definition);
        }

        public string GetID()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetID(string id)
        {
            _id = id;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void Update(PlayerDetailItem playerDetailItem)
        {
            _itemStatDefinitionRefs = playerDetailItem._itemStatDefinitionRefs;
        }
        public void Update(params ItemStatDefinitionRef[] itemStatDefinitionRefs)
        {
            foreach(var  param in itemStatDefinitionRefs)
            {
                _itemStatDefinitionRefs.Remove(param);
                _itemStatDefinitionRefs.Add(param);
            }
        }
    }
}