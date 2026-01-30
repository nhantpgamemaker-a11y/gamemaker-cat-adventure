using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class UnRefreshShopDefinition : BaseShopDefinition
    {
        public UnRefreshShopDefinition():base()
        {

        }
        public UnRefreshShopDefinition(string id, string name, string title, string description, Sprite icon, BaseMetaData metaData, List<BaseShopItemDefinition> shopItems)
        : base(id, name, title, description, icon, metaData, shopItems)
        {
            
        }
        
        public override object Clone()
        {
            return new UnRefreshShopDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), GetMetaData(), ShopItems.Select(x => x.Clone() as BaseShopItemDefinition).ToList());
        }
    }
}