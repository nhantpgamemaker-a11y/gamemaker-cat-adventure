using System;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;

namespace GameMaker.Item.Runtime
{
    public abstract class BaseDataSpaceProviderItem : IDataSpaceProvider
    {
        public abstract BaseDataSpaceSetting GetSetting();
        public abstract UniTask InitAsync();

        public abstract UniTask<bool> UpdatePlayerDetailItemAsync(PlayerDetailItem playerDetailItem);
        public abstract UniTask<bool> AddPlayerItemDetailAsync(PlayerDetailItem playerDetailItem);
        public abstract UniTask<bool> RemovePlayerItemDetailAsync(PlayerDetailItem playerDetailItem);
    }
}