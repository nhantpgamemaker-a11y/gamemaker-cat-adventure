using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public abstract class PlayerProperty : BasePlayerData
    {
        protected PlayerProperty(string id, IDefinition definition) : base(id, definition)
        {
        }
        public abstract string GetStringValue();
        
        public abstract void Add(string value);

        public abstract void Set(string value);
    }
}
