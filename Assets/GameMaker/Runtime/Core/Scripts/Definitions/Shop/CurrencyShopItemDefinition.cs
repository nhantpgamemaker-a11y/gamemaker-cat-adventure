using System;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class CurrencyShopItemDefinition : BaseShopItemDefinition
    {
        [UnityEngine.SerializeField]
        private BaseCreateItemTemplate _createItemTemplate;
        public BaseCreateItemTemplate CreateItemTemplate => _createItemTemplate;
        public CurrencyShopItemDefinition() : base()
        {

        }
        public CurrencyShopItemDefinition(string id, string name, string title, string description,Sprite icon, BaseMetaData metaData, string referenceId, Price price,float amount,BaseCreateItemTemplate createItemTemplate)
        :base(id, name, title, description, icon, metaData, referenceId, price,amount)
        {
            _createItemTemplate = createItemTemplate;
        }
        public override object Clone()
        {
            return new CurrencyShopItemDefinition(GetID(), GetName(), GetTitle(), GetReferenceID(), GetIcon(), GetMetaData(), GetReferenceID(), Price, Amount,_createItemTemplate);
        }

        public override IDefinition GetDefinition()
        {
            return CurrencyManager.Instance.GetDefinition(GetReferenceID());
        }
    }
}