using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Currency.Runtime
{
    [System.Serializable]
    public class PlayerCurrencyManager : PlayerDataManager
    {
        public PlayerCurrencyManager(List<PlayerCurrency> basePlayerDatas) : base(basePlayerDatas.Cast<BasePlayerData>().ToList())
        {
        }
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
        public void AddCurrency(string referenceId, float value, object extendData)
        {
            var playerCurrency = GetPlayerCurrency(referenceId);
            playerCurrency.AddValue(value);
            RuntimeActionManager.Instance.NotifyAction(CurrencyActionDefinition.ADD_CURRENCY_ACTION_DEFINITION_ID, new CurrencyActionData(referenceId,value, extendData));
        }
    }
}