using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Property.Runtime
{
    [ScriptableObjectSingletonPathAttribute("Assets/Resources/Properties")]
    [CreateAssetMenu(fileName ="PropertyManager",menuName = "GameMaker/Property")]
    public class PropertyManager : BaseScriptableObjectDataManager<PropertyManager, PropertyDefinition>
    {
        public List<StatDefinition> GetStats()
        {
            return GetDefinitions().Where(x => x.GetType() == typeof(StatDefinition)).Cast<StatDefinition>().ToList();
        }
        public List<AttributeDefinition> GetAttributes()
        {
            return GetDefinitions().Where(x => x.GetType() == typeof(AttributeDefinition)).Cast<AttributeDefinition>().ToList();
        }
        public List<PropertyDefinition> GetProperties()
        {
            return GetDefinitions().Cast<PropertyDefinition>().ToList();
        }

#if UNITY_EDITOR
        [ContextMenu("Add Stat")]
        public void AddStat()
        {
            AddDefinition(new StatDefinition());
        }
        [ContextMenu("Add Attribute")]
        public void AddAttribute()
        {
            AddDefinition(new AttributeDefinition());
        }
        #endif
    }
}