using System.Collections.Generic;
using System.Linq;
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
            return GetDefinitions().Where(x => x.ItemDefinitionId == itemDefinitionId).ToList();
        }
    }
}