using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Feature.Shop.Runtime
{
    public abstract class BaseShopDataSpaceProvider : IDataSpaceProvider
    {
        public abstract UniTask<(bool, List<PlayerShop>)> GetShopsAsync();
        public abstract UniTask<(bool status, List<BaseReceiverProduct> products, Price price)> PurchaseAsync(string shopDefinitionId, string shopItemId, float amount);
        public abstract UniTask<bool> InitAsync(BaseDataSpaceSetting baseDataSpaceSetting);
        public abstract UniTask<(bool,PlayerShop)> RefreshShopAsync(string shopDefinitionId, long lastRefreshTime);
        public virtual void Dispose(){}
    }
}