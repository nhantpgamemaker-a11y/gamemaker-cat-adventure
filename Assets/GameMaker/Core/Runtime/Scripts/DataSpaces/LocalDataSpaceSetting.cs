using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [ScriptableObjectSingletonPathAttribute("Assets/Resources/Core")]
    [CreateAssetMenu(fileName ="LocalDataSpaceSetting",menuName = "GameMaker/Core/LocalDataSpaceSetting")]
    public class LocalDataSpaceSetting : BaseDataSpaceSetting
    {
        public override async UniTask InitAsync()
        {
            
        }
    }
}