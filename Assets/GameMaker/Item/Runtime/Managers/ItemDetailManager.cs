using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Item.Runtime
{
     [ScriptableObjectSingletonPathAttribute("Assets/Resources/Items")]
    [CreateAssetMenu(fileName ="ItemDetailManager",menuName = "GameMaker/Items/ItemDetailManager")]
    public class ItemDetailManager : BaseScriptableObjectDataManager<ItemDetailManager, ItemDetailDefinition>
    {
        
    }
}