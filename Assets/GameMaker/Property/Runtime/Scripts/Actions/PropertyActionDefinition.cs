using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class PropertyActionDefinition : BaseActionDefinition
    {
        public readonly static string ADD_STAT_ACTION_DEFINITION_ID = "STAT_ADD";
        public readonly static string SET_ATTRIBUTE_ACTION_DEFINITION_ID = "ATTRIBUTE_SET";
        public PropertyActionDefinition(string id, string name, string title,string description, Sprite icon):base(id, name, title,description, icon)
        {
            
        }
        public override List<IDefinition> GetDefinitions()
        {
            return PropertyManager.Instance.GetDefinitions().Cast<IDefinition>().ToList();
        }
        public override object Clone()
        {
            return new PropertyActionDefinition(GetID(), GetName(), GetTitle(), GetDescription(), GetIcon());
        }

        public override List<BaseActionDefinition> GetCoreActionDefinition()
        {
            return new List<BaseActionDefinition>()
            {
                new PropertyActionDefinition(ADD_STAT_ACTION_DEFINITION_ID, "ADD_STAT_ACTION", "ADD_STAT_ACTION","", null),
                new PropertyActionDefinition(SET_ATTRIBUTE_ACTION_DEFINITION_ID, "SET_ATTRIBUTE_ACTION", "SET_ATTRIBUTE_ACTION","", null),
            };
        }
    }
}