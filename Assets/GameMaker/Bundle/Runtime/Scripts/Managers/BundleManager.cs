using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Bundle.Runtime
{
    [System.Serializable]
    [ScriptableObjectSingletonPathAttribute("Assets/Resources")]
    [CreateAssetMenu(fileName ="BundleManager",menuName = "GameMaker/Currency")]
    public class BundleManager : BaseScriptableObjectDataManager<BundleManager, BundleDefinition>
    {
        public List<BundleDefinition> GetBundles()
        {
            return GetDefinitions();
        }
    }
}
