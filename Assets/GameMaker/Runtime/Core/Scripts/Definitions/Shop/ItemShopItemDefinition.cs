using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class ItemShopItemDefinition : BaseShopItemDefinition
    {
        
        public ItemShopItemDefinition() : base()
        {

        }
        public ItemShopItemDefinition(string id, string name, string title, string description,Sprite icon, BaseMetaData metaData, string referenceId, Price price,float amount)
        :base(id, name, title, description, icon, metaData, referenceId, price, amount)
        {
        }
        public override object Clone()
        {
            return new ItemShopItemDefinition(GetID(), GetName(), GetTitle(), GetReferenceID(), GetIcon(), GetMetaData(), GetReferenceID(), Price, Amount);
        }

        public override IDefinition GetDefinition()
        {
            return ItemDetailManager.Instance.GetDefinition(GetReferenceID());
        }
    }
}