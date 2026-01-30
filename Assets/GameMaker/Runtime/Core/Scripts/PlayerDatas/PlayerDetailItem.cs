using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class PlayerDetailItem : BasePlayerData, IDefinition
    {
        private string _id;
        private string _name;
        private List<ItemPropertyDefinitionRef> _itemPropertyDefinitionRefs = new();
        public PlayerDetailItem(string id, string name,List<ItemPropertyDefinitionRef> itemPropertyDefinitionRefs , IDefinition definition) : base(definition)
        {
            _id = id;
            _name = name;
            _itemPropertyDefinitionRefs = itemPropertyDefinitionRefs;
        }

        public List<ItemPropertyDefinitionRef> ItemStatDefinitionRefs { get => _itemPropertyDefinitionRefs; }

        public override object Clone()
        {
            return new PlayerDetailItem(_id, _name,_itemPropertyDefinitionRefs,definition);
        }

        public override void CopyFrom(BasePlayerData basePlayerData)
        {
            _itemPropertyDefinitionRefs = (basePlayerData as PlayerDetailItem).ItemStatDefinitionRefs;
            NotifyObserver(this);
        }

        public string GetID()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void Update(PlayerDetailItem playerDetailItem)
        {
            _itemPropertyDefinitionRefs = playerDetailItem._itemPropertyDefinitionRefs;
            NotifyObserver(this);
        }
        public void Update(params ItemStatDefinitionRef[] itemStatDefinitionRefs)
        {
            foreach (var param in itemStatDefinitionRefs)
            {
                _itemPropertyDefinitionRefs.Remove(param);
                _itemPropertyDefinitionRefs.Add(param);
            }
            NotifyObserver(this);
        }
    }
}