using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Feature.Shop.Runtime
{
    [DataSpace(nameof(LocalDataSpaceSetting.LOCAL_SPACE))]
    public class LocalShopDataSpaceProvider : BaseShopDataSpaceProvider
    {
        private LocalShopSaveData _localShopSaveData;
        public async override UniTask<bool> InitAsync(BaseDataSpaceSetting baseDataSpaceSetting)
        {
            _localShopSaveData = (baseDataSpaceSetting as LocalDataSpaceSetting).LocalDataManager.Get<LocalShopSaveData>();
            return true;
        }


        public async override UniTask<(bool status, List<BaseReceiverProduct> products, Price price)> PurchaseAsync(string shopDefinitionId, string shopItemId, float amount)
        {
            var shopDefinition = ShopManager.Instance.GetDefinition(shopDefinitionId);
            var shopItemDefinition = shopDefinition.GetShopItemDefinition(shopItemId);
            return (true, new(), shopItemDefinition.Price);
        }
        public async override UniTask<(bool, List<PlayerShop>)> GetShopsAsync()
        {
            return (true, _localShopSaveData.GetPlayerShops());
        }

        public async override UniTask<(bool, PlayerShop)> RefreshShopAsync(string shopDefinitionId, long lastRefreshTime)
        {
            var newPlayerShop = await _localShopSaveData.RefreshShopAsync(shopDefinitionId, lastRefreshTime);
            return (true, newPlayerShop);
        }
    }
}