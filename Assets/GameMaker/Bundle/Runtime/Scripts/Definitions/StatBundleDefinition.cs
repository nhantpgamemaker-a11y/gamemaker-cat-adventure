using GameMaker.Core.Runtime;
using GameMaker.Property.Runtime;
using UnityEngine;

namespace GameMaker.Bundle.Runtime
{
    public enum UpdateType : int
    {
        Add = 1,

        Override = 2,

        OverrideIfGreater = 3,

        AddToCurrentTime = 4,

        Remove = 5
    }
    [System.Serializable]
    public class StatBundleItemDefinition : BaseBundleItemDefinition
    {
        [UnityEngine.SerializeField]
        private UpdateType _updateType;
        public UpdateType UpdateType => _updateType;
        public StatBundleItemDefinition(string id, string name, string title, string description, Sprite icon,float amount, UpdateType updateType): base(id, name, title, description, icon,amount)
        {
            _updateType = updateType;
        }
        public override object Clone()
        {
            return new StatBundleItemDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon(), Amount, UpdateType);
        }

        public override IDefinition GetDefinition()
        {
            return PropertyManager.Instance.GetDefinition(GetReferenceID());
        }
    }
}