using GameMaker.Core.Editor;
using GameMaker.Currency.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Currency.Editor
{
    [CustomPropertyDrawer(typeof(CurrencyDefinition))]
    public class CurrencyDefinitionPropertyDrawer : BaseDefinitionPropertyDrawer
    {
        protected override BaseDefinitionHolder GetBaseDefinitionHolder()
        {
            var asset = Resources.Load<VisualTreeAsset>("CurrencyDefinitionElement");
            TemplateContainer templateContainer = asset.CloneTree();
            return new CurrencyDefinitionHolder(templateContainer);
        }
    }
}