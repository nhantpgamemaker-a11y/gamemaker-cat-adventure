using GameMaker.Core.Runtime;
using GameMaker.Currency.Runtime;
using GameMaker.Property.Runtime;
using UnityEngine;

namespace GameMaker.Bundle.Runtime
{
    [System.Serializable]
    public class CurrencyBundleItemDefinition : BaseBundleItemDefinition
    {
        public CurrencyBundleItemDefinition(string id, string name, string title, string description, Sprite icon,float amount): base(id, name, title, description, icon,amount)
        {
        }
        public override object Clone()
        {
            return new CurrencyBundleItemDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), Amount);
        }

        public override IDefinition GetDefinition()
        {
            return CurrencyManager.Instance.GetDefinition(GetReferenceID());
        }
    }
}