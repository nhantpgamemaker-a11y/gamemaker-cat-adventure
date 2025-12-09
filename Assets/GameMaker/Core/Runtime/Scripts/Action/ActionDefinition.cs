using System.Collections.Generic;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public abstract class BaseActionDefinition : BaseDefinition
    {
        public BaseActionDefinition(string id, string name, string title):base(id, name, title)
        {
            
        }
        public abstract List<IDefinition> GetDefinitions();
        public abstract List<BaseActionDefinition> GetCoreActionDefinition();
    }
}