using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class StatActionData : PropertyActionData
    {
        public const string ADD_STAT_ACTION_DEFINITION = "ADD_STAT_ACTION_DEFINITION";
         public const string SET_STAT_ACTION_DEFINITION = "SET_STAT_ACTION_DEFINITION";
        private float _value;
        public float Value { get => _value; }
        public StatActionData(): base(){}
        public StatActionData(string propertyId, float value, IExtendData extendData) : base(propertyId, extendData)
        {
            _value = value;
        }
        public override List<ActionDefinition> GetGenerateActionDefinitions()
        {
            List<ActionDefinition> actionDefinitions = new();
            var actionParamManager = new BaseDefinitionManager<BaseActionParamDefinition>();
            actionParamManager.AddDefinition(new StatActionParamDefinition("StatID", "StatID", "_propertyId"));
            actionParamManager.AddDefinition(new FloatActionParamDefinition("Value", "Value", "_value"));
            ActionDefinition actionDefinition = new(ADD_STAT_ACTION_DEFINITION, ADD_STAT_ACTION_DEFINITION, actionParamManager);
            actionDefinitions.Add(actionDefinition);

            actionParamManager = new BaseDefinitionManager<BaseActionParamDefinition>();
            actionParamManager.AddDefinition(new StatActionParamDefinition("StatID", "StatID", "_propertyId"));
            actionParamManager.AddDefinition(new FloatActionParamDefinition("Value", "Value", "_value"));
            actionDefinition = new(SET_STAT_ACTION_DEFINITION, SET_STAT_ACTION_DEFINITION, actionParamManager);
            actionDefinitions.Add(actionDefinition);

            return actionDefinitions;
        }
    }
}