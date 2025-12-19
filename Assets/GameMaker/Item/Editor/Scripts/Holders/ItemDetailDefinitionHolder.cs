using GameMaker.Core.Editor;
using GameMaker.Item.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Item.Editor
{
    public class ItemDetailDefinitionHolder : BaseDefinitionHolder
    {
        private TemplateContainer _dataManagementTemplateContainer;
        private BaseDataManagerHolder<ItemDetailDefinition> _itemDetailDefinitionManagerHolder;
        public ItemDetailDefinitionHolder(VisualElement root) : base(root)
        {
            
        }
    }
}
