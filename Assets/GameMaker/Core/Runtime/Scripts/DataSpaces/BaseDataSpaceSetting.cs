using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    public abstract class BaseDataSpaceSetting: ScriptableObjectSingleton<BaseDataSpaceSetting>
    {
        public abstract UniTask InitAsync();
    }
}