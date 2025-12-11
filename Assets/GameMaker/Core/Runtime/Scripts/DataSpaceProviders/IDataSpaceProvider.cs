using System;
using Cysharp.Threading.Tasks;

namespace GameMaker.Core.Runtime
{
    public interface IDataSpaceProvider
    {
        public UniTask InitAsync();
        public BaseDataSpaceSetting GetSetting();
    }
}