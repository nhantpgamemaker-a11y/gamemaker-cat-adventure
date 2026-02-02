using System.Collections.Generic;
using System.Linq;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class PlayerCurrencyManager : PlayerDataManager
    {   
        public void AddObserver(IObserverWithScope<PlayerCurrency, string> observer, string[] scopes)
        {
            AddObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public void RemoveObserver(IObserverWithScope<PlayerCurrency, string> observer, string[] scopes)
        {
            RemoveObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public PlayerCurrency GetPlayerCurrency(string referenceId)
        {
            return GetPlayerData(referenceId) as PlayerCurrency;
        }
        public List<PlayerCurrency> GetPlayerCurrencies()
        {
            return basePlayerDatas.Cast<PlayerCurrency>().ToList();
        }
        public void AddPlayerCurrency(string id, float value)
        {
            var playerCurrency = GetPlayerCurrency(id);
            playerCurrency.AddValue(value);
        }
    }
}