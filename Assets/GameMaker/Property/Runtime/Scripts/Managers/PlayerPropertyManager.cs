using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class PlayerPropertyManager : PlayerDataManager
    {
        public PlayerPropertyManager(List<PlayerProperty> basePlayerDatas) : base(basePlayerDatas.Cast<BasePlayerData>().ToList())
        {

        }
        public PlayerProperty GetProperty(string referenceId)
        {
            return GetPlayerData(referenceId) as PlayerProperty;
        }
        public void AddObserver(IObserverWithScope<PlayerProperty, string> observer, string[] scopes)
        {
            AddObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public void RemoveObserver(IObserverWithScope<PlayerProperty, string> observer, string[] scopes)
        {
            RemoveObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public void AddStat(string referenceId, float value, object extendData =null)
        {
            var playerProperty = GetPlayerData(referenceId);
            var playerStat = playerProperty as PlayerStat;
            playerStat.AddValue(value);
            RuntimeActionManager.Instance.NotifyAction(PropertyActionDefinition.ADD_STAT_ACTION_DEFINITION_ID,
            new StatActionData(referenceId, value, extendData));
        }
        public void SetAttribute(string referenceId, string value, object extendData)
        {
            var playerProperty = GetPlayerData(referenceId);
            var playerAttribute = playerProperty as PlayerAttribute;
            playerAttribute.SetValue(value);
            RuntimeActionManager.Instance.NotifyAction(PropertyActionDefinition.SET_ATTRIBUTE_ACTION_DEFINITION_ID,
            new AttributeActionData(referenceId, value, extendData));
        }
    }
}