using System.Collections.Generic;
using GameMaker.Core.Editor;
using GameMaker.Core.Runtime;
using GameMaker.Item.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Item.Editor
{
    [CustomPropertyDrawer(typeof(BaseDefinitionManager<ItemDetailDefinition>))]
    public class ItemDetailDataManagerPropertyHolder : Core.Editor.BaseDataManagerPropertyDrawer<ItemDetailDefinition>
    {
        protected override BaseDataManagerHolder<ItemDetailDefinition> CreateBaseDataManagerHolder()
        {
            var asset = Resources.Load<VisualTreeAsset>("FilterDataManagerElement");
            var templateContainer = asset.CloneTree();
            templateContainer.style.height = StyleKeyword.Auto;
            templateContainer.style.flexGrow = 1;

            List<BaseFilterHolder> filters = new();
            var idFilter = new StringFilter("Id", "id");
            var stringAsset = Resources.Load<VisualTreeAsset>("StringFilterElement");
            var itemFilterHolder = new StringFilterHolder(stringAsset.CloneTree(),idFilter);
            var nameFilter = new StringFilter("Name", "name");
            var nameFilterHolder = new StringFilterHolder(stringAsset.CloneTree(),nameFilter);
            var titleFilter = new StringFilter("Title", "title");
            var titleFilterHolder = new StringFilterHolder(stringAsset.CloneTree(),titleFilter);
            filters.Add(itemFilterHolder);
            filters.Add(nameFilterHolder);
            filters.Add(titleFilterHolder);

            return new ItemDetailDataManagerHolder(templateContainer, filters);
        }
    }
    public class ItemDetailDataManagerHolder : FilterDataManagerHolder<ItemDetailDefinition>
    {
        public ItemDetailDataManagerHolder(VisualElement root, List<BaseFilterHolder> filters) : base(root, filters)
        {
        }

        protected override string GetTitle()
        {
            return "Item Detail";
        }

        protected override BaseDefinitionHolder CreateHolder()
        {
            var asset = Resources.Load<VisualTreeAsset>(
            "ItemDetailDefinitionElement");
            var templateContainer = asset.CloneTree();
            templateContainer.style.height = StyleKeyword.Auto;
            templateContainer.style.flexGrow = 1;
            return new ItemDetailDefinitionHolder(asset.CloneTree());
        }
    }
}
