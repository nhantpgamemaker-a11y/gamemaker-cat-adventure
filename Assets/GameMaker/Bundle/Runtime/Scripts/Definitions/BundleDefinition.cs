using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Bundle.Runtime
{
    [System.Serializable]
    public class BundleDefinition : BaseDefinition
    {
        [UnityEngine.SerializeReference]
        private List<BaseBundleItemDefinition> _bundleItems;
        public  List<BaseBundleItemDefinition> BundleItems { get => _bundleItems; }
        public BundleDefinition() : base()
        {
            _bundleItems = new();
        }
        public BundleDefinition(string id,
                                string name,
                                string title,
                                string description,
                                Sprite icon,
                                List<BaseBundleItemDefinition> bundleItems) : base(id, name, title, description, icon)
        {
            _bundleItems = bundleItems;
        }


        public override object Clone()
        {
            return new BundleDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), _bundleItems.Select(x => x.Clone() as BaseBundleItemDefinition).ToList());
        }
    }
}
