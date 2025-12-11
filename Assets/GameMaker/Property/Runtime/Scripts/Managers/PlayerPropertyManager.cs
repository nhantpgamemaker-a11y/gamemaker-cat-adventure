using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class PlayerPropertyManager : PlayerDataManager
    {
        private BaseDataSpaceProviderProperty _baseDataSpaceProviderProperty;
        public PlayerPropertyManager(BaseDataSpaceProviderProperty baseDataSpaceProviderProperty,List<PlayerProperty> basePlayerDatas) : base(basePlayerDatas.Cast<BasePlayerData>().ToList())
        {
            _baseDataSpaceProviderProperty = baseDataSpaceProviderProperty;
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
        public async UniTask<bool> AddStatAsync(string referenceId, float value, IExtendData extendData)
        {
            bool status = await _baseDataSpaceProviderProperty.AddStatAsync(referenceId, value);
            if (status)
            {
                AddStatRuntime(referenceId, value, extendData);
            }
            return status;
            
        }
        public void AddStatRuntime(string referenceId, float value, IExtendData extendData)
        {
            var playerProperty = GetPlayerData(referenceId);
            var playerStat = playerProperty as PlayerStat;
            playerStat.AddValue(value);
            RuntimeActionManager.Instance.NotifyAction(PropertyActionDefinition.ADD_STAT_ACTION_DEFINITION_ID,
            new StatActionData(referenceId, value, extendData));
        }
        public async UniTask<bool> SetAttributeAsync(string referenceId, string value, IExtendData extendData)
        {
            bool status = await _baseDataSpaceProviderProperty.SetAttributeAsync(referenceId, value);
            if (status)
            {
                SetAttributeRuntime(referenceId, value, extendData);
            }
            return status;
        }
        public void SetAttributeRuntime(string referenceId, string value, IExtendData extendData)
        {
            var playerProperty = GetPlayerData(referenceId);
            var playerAttribute = playerProperty as PlayerAttribute;
            playerAttribute.SetValue(value);
            RuntimeActionManager.Instance.NotifyAction(PropertyActionDefinition.SET_ATTRIBUTE_ACTION_DEFINITION_ID,
            new AttributeActionData(referenceId, value, extendData));
        }
    }
}