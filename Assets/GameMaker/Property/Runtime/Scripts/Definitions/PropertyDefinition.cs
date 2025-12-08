using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public abstract class PropertyDefinition : BaseDefinition
    {
        public PropertyDefinition() : base()
        {
            
        }
        public PropertyDefinition(string id, string name, string title) : base(id, name, title)
        {

        }
    }
}