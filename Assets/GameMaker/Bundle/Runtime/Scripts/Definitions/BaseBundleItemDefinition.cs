using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Bundle.Runtime
{
    [System.Serializable]
    public abstract class BaseBundleItemDefinition : BaseDefinition, IReferenceDefinition
    {
        [UnityEngine.SerializeField]
        private string _referenceId;

        [UnityEngine.SerializeField]
        private float _amount;
        public float Amount { get => _amount; }
        public BaseBundleItemDefinition():base()
        {
            
        }
        public BaseBundleItemDefinition(string id,
                                string name,
                                string title,
                                string description,
                                Sprite icon,
                                float amount) : base(id, name, title, description, icon)
        {
            _amount = amount;
        }

        public abstract IDefinition GetDefinition();

        public string GetReferenceID()
        {
            return _referenceId;
        }
    }
}