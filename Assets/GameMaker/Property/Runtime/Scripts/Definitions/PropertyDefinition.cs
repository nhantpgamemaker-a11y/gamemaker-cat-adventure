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
        public PropertyDefinition(string id, string name, string title,string description, Sprite icon):base(id, name, title,description, icon)
        {

        }
    }
}