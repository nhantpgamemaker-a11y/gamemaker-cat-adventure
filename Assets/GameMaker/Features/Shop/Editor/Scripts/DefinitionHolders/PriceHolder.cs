using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Editor;
using GameMaker.Core.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GameMaker.Feature.Shop.Editor
{
    public class PriceHolder : BaseHolder
    {
        private DropdownField _currencyDropdownField;
        private LongField _amountLongField;
        private List<BaseCurrencyDefinition> _currencyDefinitions;
        public PriceHolder(VisualElement root) : base(root)
        {
            _currencyDropdownField = root.Q<DropdownField>("CurrencyDropdownField");
            _amountLongField = root.Q<LongField>("AmountLongField");
        }
        public override void Bind(SerializedProperty elementProperty)
        {
            _currencyDefinitions = CurrencyManager.Instance.GetDefinitions().ToList();
            _amountLongField.BindProperty(elementProperty.FindPropertyRelative("_amount"));
            _currencyDropdownField.choices = _currencyDefinitions.Select(x => x.GetName()).ToList();
            var currencyReferenceId = elementProperty.FindPropertyRelative("_currencyReferenceId").stringValue;
            var currencyDefinition = _currencyDefinitions.FirstOrDefault(x => x.GetID() == currencyReferenceId);
            if(currencyDefinition != null)
            {
                _currencyDropdownField.value = currencyDefinition.GetName();
            }
            else
            {
                _currencyDropdownField.value = _currencyDefinitions.First().GetName();
                elementProperty.FindPropertyRelative("_currencyReferenceId").stringValue = _currencyDefinitions.First().GetID();
            }
            _currencyDropdownField.RegisterValueChangedCallback(value =>
            {
                var currencyDefinition = _currencyDefinitions.FirstOrDefault(x => x.GetName() == value.newValue);
                if(currencyDefinition != null)
                {
                    elementProperty.FindPropertyRelative("_currencyReferenceId").stringValue = currencyDefinition.GetID();
                }
                elementProperty.serializedObject.ApplyModifiedProperties();
            });

        }
    }
}