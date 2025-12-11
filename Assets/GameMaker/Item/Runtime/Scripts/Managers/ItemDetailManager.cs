using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
    [ScriptableObjectSingletonPathAttribute("Assets/Resources/Items")]
    [CreateAssetMenu(fileName ="ItemDetailManager",menuName = "GameMaker/Items/ItemDetailManager")]
    public class ItemDetailManager : BaseScriptableObjectDataManager<ItemDetailManager, ItemDetailDefinition>
    {
        public List<ItemDetailDefinition> GetItemDetailDefinitions(string itemDefinitionId)
        {
            return GetDefinitions(x => x.ItemDefinitionId == itemDefinitionId);
        }
    }
}