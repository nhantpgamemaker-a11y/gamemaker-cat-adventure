using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
    public class PlayerItemDetailManager : PlayerDataManager
    {
        private BaseDataSpaceProviderItem _baseDataSpaceProviderItem;
        private ObservableCollection<PlayerDetailItem> _playerDetailItems;
        private List<Action<object, NotifyCollectionChangedEventArgs>> _actions = new();
        public PlayerItemDetailManager(BaseDataSpaceProviderItem baseDataSpaceProviderItem,List<PlayerDetailItem> basePlayerDatas) : base(basePlayerDatas.Cast<BasePlayerData>().ToList())
        {
            _baseDataSpaceProviderItem = baseDataSpaceProviderItem;
            _playerDetailItems = new ObservableCollection<PlayerDetailItem>(basePlayerDatas);
            _playerDetailItems.CollectionChanged += OnCollectionChanged;
        }
        ~PlayerItemDetailManager()
        {
            _playerDetailItems.CollectionChanged -= OnCollectionChanged;
        }
        public void AddObserver(IObserverWithScope<PlayerDetailItem, string> observer, string[] scopes)
        {
            AddObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public void RemoveObserver(IObserverWithScope<PlayerDetailItem, string> observer, string[] scopes)
        {
            RemoveObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public PlayerDetailItem GetPlayerDetailItem(string referenceId)
        {
            return basePlayerDatas.FirstOrDefault(x => (x as PlayerDetailItem).GetID() == referenceId) as PlayerDetailItem;
        }
        public async UniTask<bool> UpdatePlayerDetailItemAsync(string referenceId, PlayerDetailItem playerDetailItem,IExtendData extendData)
        {
            var playerItem = GetPlayerDetailItem(referenceId);
            bool status = await _baseDataSpaceProviderItem.UpdatePlayerDetailItemAsync(playerDetailItem);
            if (status)
            {
                playerItem.Update(playerDetailItem);
            }
            return status;
        }
        public async UniTask<bool> AddPlayerItemAsync(PlayerDetailItem playerDetailItem,IExtendData extendData)
        {
            var status = await _baseDataSpaceProviderItem.AddPlayerItemDetailAsync(playerDetailItem);
            if (status)
            {
                basePlayerDatas.Add(playerDetailItem);
                _playerDetailItems.Add(playerDetailItem);
                var itemDetailDefinition = playerDetailItem.GetDefinition() as ItemDetailDefinition;
                var itemDefinition = itemDetailDefinition.GetItemDefinition();
                RuntimeActionManager.Instance.NotifyAction(ItemActionDefinition.ADD_ITEM_ACTION_DEFINITION_ID, new ItemActionData(itemDefinition.GetID()));
                RuntimeActionManager.Instance.NotifyAction(ItemDetailActionDefinition.ADD_ITEM_DETAIL_ACTION_DEFINITION_ID, new ItemDetailActionData(itemDetailDefinition.GetID()));
            }
            return status;
        }
        public async UniTask<bool> RemovePlayerItemAsync(PlayerDetailItem playerDetailItem,IExtendData extendData)
        {
            var status = await _baseDataSpaceProviderItem.RemovePlayerItemDetailAsync(playerDetailItem);
            if (status)
            {
                basePlayerDatas.Remove(playerDetailItem);
                _playerDetailItems.Remove(playerDetailItem);
                var itemDetailDefinition = playerDetailItem.GetDefinition() as ItemDetailDefinition;
                var itemDefinition = itemDetailDefinition.GetItemDefinition();
                RuntimeActionManager.Instance.NotifyAction(ItemActionDefinition.REMOVE_ITEM_ACTION_DEFINITION_ID, new ItemActionData(itemDefinition.GetID()));
                RuntimeActionManager.Instance.NotifyAction(ItemDetailActionDefinition.REMOVE_ITEM_DETAIL_ACTION_DEFINITION_ID, new ItemDetailActionData(itemDetailDefinition.GetID()));
            }
            return status;
        }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            _actions.ForEach(a => a.Invoke(sender, notifyCollectionChangedEventArgs));
        }
    }
}