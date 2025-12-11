using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using Newtonsoft.Json;
using UnityEngine;

namespace GameMaker.Currency.Runtime
{
    [System.Serializable]
    public class LocalCurrencySaveData : BaseLocalData
    {
        [JsonProperty("PlayerCurrencies")]
        [SerializeField]
        private List<PlayerCurrencyModel> _playerCurrencies = new();

        public List<PlayerCurrency> GetPlayerCurrencies()
        {
            return _playerCurrencies.Select(x => x.ToPlayerCurrency()).ToList();
        }
        public PlayerCurrency GetPlayerCurrency(string currencyId)
        {
            return _playerCurrencies.FirstOrDefault(x => x.GetID() == currencyId)?.ToPlayerCurrency();
        }

        public async UniTask AddPlayerCurrency(string currencyDefinitionId, float value)
        {
            var playerCurrency = _playerCurrencies.FirstOrDefault(x => x.GetID() == currencyDefinitionId);
            if (playerCurrency == null)
            {
                var currencyDefinition = CurrencyManager.Instance.GetDefinition(currencyDefinitionId);
                _playerCurrencies.Add(new PlayerCurrencyModel(currencyDefinitionId, currencyDefinition.GetName(), value));
            }
            else
            {
                playerCurrency.AddValue(value);
            }
            await SaveAsync();
        }
    }
    
    [System.Serializable]
    public class PlayerCurrencyModel: PlayerDataModel
    {
        [JsonProperty("Value")]
        private float _value;
        public PlayerCurrencyModel(string id, string name, float value):base(id, name)
        {
            base.id = id;
            base.name = name;
            _value = value;
        }
        public void AddValue(float value)
        {
            _value += value;
        }
        public float GetValue()
        {
            return _value;
        }

        public PlayerCurrency ToPlayerCurrency()
        {
            var currencyDefinition =  CurrencyManager.Instance.GetDefinition(id);
            return new PlayerCurrency(currencyDefinition,_value);
        }
    }
}