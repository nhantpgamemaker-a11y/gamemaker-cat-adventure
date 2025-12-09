using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public abstract class PlayerProperty : BasePlayerData
    {
        protected PlayerProperty(IDefinition definition) : base(definition)
        {
        }
    }
}
