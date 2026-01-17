using GameMaker.Core.Runtime;
using GameMaker.Currency.Runtime;
using GameMaker.Item.Runtime;
using GameMaker.Property.Runtime;
using UnityEngine;

namespace GameMaker.Bundle.Runtime
{
    [System.Serializable]
    public class ItemBundleItemDefinition : BaseBundleItemDefinition
    {
        private BaseCreateItemTemplate _createItemTemplate;
        public BaseCreateItemTemplate CreateItemTemplate=> _createItemTemplate;
        public ItemBundleItemDefinition(string id, string name, string title, string description, Sprite icon,float amount): base(id, name, title, description, icon,amount)
        {
            
        }
        public override object Clone()
        {
            return new ItemBundleItemDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), Amount);
        }

        public override IDefinition GetDefinition()
        {
            return ItemManager.Instance.GetDefinition(GetReferenceID());
        }
    }
}