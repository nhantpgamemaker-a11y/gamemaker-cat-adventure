using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;

namespace GameMaker.Currency.Runtime
{
    public class LocalDataSpaceProviderCurrency : BaseDataSpaceProviderCurrency
    {
        private LocalCurrencySaveData _localCurrencySaveData = null;
        
        public override async UniTask InitAsync()
        {
            _localCurrencySaveData = LocalDataManager.Instance.Get<LocalCurrencySaveData>();
        }
        
        public override async UniTask<bool> AddCurrencyAsync(string currencyDefinitionId, float value)
        {
            await _localCurrencySaveData.AddPlayerCurrency(currencyDefinitionId, value);
            return true;
        }

        public override async UniTask<(bool status,List<PlayerCurrency> playerCurrencies)> GetPlayerCurrenciesAsync()
        {
            var playerCurrencies = _localCurrencySaveData.GetPlayerCurrencies();
            return (true, playerCurrencies);
        }

        public override async UniTask<(bool status, PlayerCurrency playerCurrency)> GetPlayerCurrencyAsync(string currencyDefinitionId)
        {
            var playerCurrency = _localCurrencySaveData.GetPlayerCurrency(currencyDefinitionId);
            return (true, playerCurrency);
        }

        public override BaseDataSpaceSetting GetSetting()
        {
            return LocalDataSpaceSetting.Instance;
        }
    }
}