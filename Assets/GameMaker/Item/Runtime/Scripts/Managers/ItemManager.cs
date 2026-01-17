using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
     [ScriptableObjectSingletonPathAttribute("Assets/Resources")]
    [CreateAssetMenu(fileName ="ItemManager",menuName = "GameMaker/Items/ItemManager")]
    public class ItemManager : BaseScriptableObjectDataManager<ItemManager, ItemDefinition>
    {
    }
}