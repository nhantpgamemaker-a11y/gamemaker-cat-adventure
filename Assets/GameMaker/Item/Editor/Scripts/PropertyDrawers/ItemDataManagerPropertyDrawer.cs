using GameMaker.Core.Editor;
using GameMaker.Core.Runtime;
using GameMaker.Item.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Item.Editor
{
    [CustomPropertyDrawer(typeof(BaseDefinitionManager<ItemDefinition>))]
    public class ItemDataManagerPropertyDrawer : Core.Editor.BaseDataManagerPropertyDrawer<ItemDefinition>
    {
        protected override BaseDataManagerHolder<ItemDefinition> CreateBaseDataManagerHolder()
        {
            var asset = Resources.Load<VisualTreeAsset>("DataManagerElement");
            var templateContainer = asset.CloneTree();
            templateContainer.style.height = StyleKeyword.Auto;
            templateContainer.style.flexGrow = 1;
            return new CurrencyDataManagerHolder(templateContainer);
        }
    }
    public class CurrencyDataManagerHolder : BaseDataManagerHolder<ItemDefinition>
    {
        public CurrencyDataManagerHolder(VisualElement root) : base(root)
        {

        }
        protected override string GetTitle()
        {
            return "Currency";
        }

        protected override BaseDefinitionHolder CreateHolder()
        {
            var asset = Resources.Load<VisualTreeAsset>(
            "ItemDefinitionElement");
            var templateContainer = asset.CloneTree();
            templateContainer.style.height = StyleKeyword.Auto;
            templateContainer.style.flexGrow = 1;
            return new ItemDefinitionHolder(asset.CloneTree());
        }
    }
}
