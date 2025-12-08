using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Currency.Runtime
{
    [ScriptableObjectSingletonPathAttribute("Assets/Resources/Currencies")]
    [CreateAssetMenu(fileName ="CurrencyManager",menuName = "GameMaker/Currency")]
    public class CurrencyManager : BaseScriptableObjectDataManager<CurrencyManager, CurrencyDefinition>
    {
        public List<CurrencyDefinition> GetCurrencies()
        {
            return GetDefinitions().Cast<CurrencyDefinition>().ToList();
        }

#if UNITY_EDITOR
        [ContextMenu("Add Currency")]
        public void AddStat()
        {
            AddDefinition(new CurrencyDefinition());
        }
        #endif
    }
}