using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace GameMaker.Currency.Runtime
{
    public abstract class BaseDataSpaceProviderCurrency : IDataSpaceProvider
    {
        public abstract UniTask InitAsync();
        
        public abstract BaseDataSpaceSetting GetSetting();
        
        public abstract UniTask<bool> AddCurrencyAsync(string currencyDefinitionId, float value);

        public abstract UniTask<(bool status, List<PlayerCurrency> playerCurrencies)> GetPlayerCurrenciesAsync();

        public abstract UniTask<(bool status, PlayerCurrency playerCurrency)> GetPlayerCurrencyAsync(string currencyDefinitionId);
        
    }
}