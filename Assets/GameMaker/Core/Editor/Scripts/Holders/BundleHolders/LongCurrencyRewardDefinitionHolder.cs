using GameMaker.Core.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GameMaker.Core.Runtime
{
    [TypeContain(typeof(LongCurrencyRewardDefinition))]
    public class LongCurrencyRewardDefinitionHolder : BaseCurrencyRewardDefinitionHolder
    {
        private LongField _amountLongField;

        public LongCurrencyRewardDefinitionHolder(VisualElement root) : base(root)
        {
            _amountLongField = root.Q<LongField>("AmountLongField");

        }
        public override void Bind(SerializedProperty elementProperty)
        {
            base.Bind(elementProperty);
            _amountLongField.BindProperty(serializedProperty.FindPropertyRelative("_amount"));
        }
        public override VisualTreeAsset GetVisualTreeAsset()
        {
            return UIToolkitLoaderUtils.LoadUXML("LongCurrencyRewardDefinitionElement");
        }
    }
}