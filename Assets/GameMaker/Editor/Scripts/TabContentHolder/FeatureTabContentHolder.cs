using GameMaker.Core.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Core.Editor
{
    [CoreTabContext]
    public class FeatureTabContentHolder : BaseTabContentHolder
    {
        private TemplateContainer _templateContainer;
        public FeatureTabContentHolder(VisualElement root) : base(root)
        {
            _templateContainer = new TemplateContainer();
        }

        public override int GetIndex()
        {
            return int.MaxValue;
        }

        public override VisualElement GetTabView()
        {
            return _templateContainer;
        }

        public override string GetTitle()
        {
            return "FEATURE";
        }
    }
}
