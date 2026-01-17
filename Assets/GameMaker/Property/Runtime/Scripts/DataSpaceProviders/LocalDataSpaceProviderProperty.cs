using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    public class LocalDataSpaceProviderProperty : BaseDataSpaceProviderProperty
    {
        public override BaseDataSpaceSetting GetSetting()
        {
            return LocalDataSpaceSetting.Instance;
        }

        public async override UniTask InitAsync()
        {
            //_localPropertySaveData = LocalDataManager.Instance.Get<LocalPropertySaveData>();
        }

        private LocalPropertySaveData _localPropertySaveData;
        public async override UniTask<bool> AddStatAsync(string referenceId, float value)
        {
            await _localPropertySaveData.AddPlayerStat(referenceId, value);
            return true;
        }
        public override async UniTask<bool> SetAttributeAsync(string referenceId, string value)
        {
            await _localPropertySaveData.SetPlayerAttribute(referenceId, value);
            return true;
        }
    }
}