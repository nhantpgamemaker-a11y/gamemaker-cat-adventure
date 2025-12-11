using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    public abstract class BaseDataSpaceProviderProperty : IDataSpaceProvider
    {
        public abstract BaseDataSpaceSetting GetSetting();

        public abstract UniTask InitAsync();

        public abstract UniTask<bool> AddStatAsync(string referenceId, float value);

        public abstract UniTask<bool> SetAttributeAsync(string referenceId, string value);
    }
}