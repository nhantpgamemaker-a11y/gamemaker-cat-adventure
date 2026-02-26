using GameMaker.Core.Editor;
using GameMaker.Core.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GameMaker.Feature.Shop.Editor
{
    [GameMaker.Core.Runtime.TypeCache]
    public abstract class BaseShopItemDefinitionHolder : BaseDefinitionHolder
    {
        private DropdownField _definitionDropdown;
        private PriceHolder _priceHolder;
        private IntegerField _amountIntegerField;
        protected BaseShopItemDefinitionHolder(VisualElement root) : base(root)
        {
            _definitionDropdown = root.Q<DropdownField>("DefinitionDropdown");
            _priceHolder = new PriceHolder(root.Q<VisualElement>("PriceHolder"));
            _amountIntegerField = root.Q<IntegerField>("AmountIntegerField");
        }
        public override void Bind(SerializedProperty elementProperty)
        {
            base.Bind(elementProperty);
            _priceHolder.Bind(elementProperty.FindPropertyRelative("_price"));
            _amountIntegerField.BindProperty(elementProperty.FindPropertyRelative("_amount"));
        }
    }
}