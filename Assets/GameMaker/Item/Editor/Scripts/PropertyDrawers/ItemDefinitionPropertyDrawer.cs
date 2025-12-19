using GameMaker.Core.Editor;
using GameMaker.Item.Runtime;
using Mono.Cecil.Cil;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Item.Editor
{
    [CustomPropertyDrawer(typeof(ItemDefinition))]
    public class ItemDefinitionPropertyDrawer : BaseDefinitionPropertyDrawer
    {
        ItemDefinitionHolder _itemDefinitionHolder;
        protected override BaseDefinitionHolder GetBaseDefinitionHolder()
        {
            var asset = Resources.Load<VisualTreeAsset>("ItemDefinitionElement");
            TemplateContainer templateContainer = asset.CloneTree();
            _itemDefinitionHolder = new ItemDefinitionHolder(templateContainer);
            return _itemDefinitionHolder;
        }
    }
}