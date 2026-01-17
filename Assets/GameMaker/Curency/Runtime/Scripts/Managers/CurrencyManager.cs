using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Currency.Runtime
{
    [System.Serializable]
    [ScriptableObjectSingletonPathAttribute("Assets/Resources")]
    [CreateAssetMenu(fileName ="CurrencyManager",menuName = "GameMaker/Currency")]
    public class CurrencyManager : BaseScriptableObjectDataManager<CurrencyManager, CurrencyDefinition>
    {
        public List<CurrencyDefinition> GetCurrencies()
        {
            return GetDefinitions();
        }
    }
}