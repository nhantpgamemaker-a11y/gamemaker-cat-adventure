using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class AttributeActionData : PropertyActionData
    {
          public const string SET_ATTRIBUTE_ACTION_DEFINITION = "SET_ATTRIBUTE_ACTION_DEFINITION";
        private string _value;
        public string Value { get => _value; }
        public AttributeActionData():base(){}
        public AttributeActionData(string propertyId, string value, IExtendData extendData) : base(propertyId, extendData)
        {
            _value = value;
        }

        public override List<ActionDefinition> GetGenerateActionDefinitions()
        {
             List<ActionDefinition> actionDefinitions = new();
            var actionParamManager = new BaseDefinitionManager<BaseActionParamDefinition>();
            actionParamManager.AddDefinition(new StringActionParamDefinition("AttributeID", "AttributeID", "_propertyId"));
            actionParamManager.AddDefinition(new FloatActionParamDefinition("Value", "Value", "_value"));
            ActionDefinition actionDefinition = new(SET_ATTRIBUTE_ACTION_DEFINITION, SET_ATTRIBUTE_ACTION_DEFINITION, actionParamManager);
            actionDefinitions.Add(actionDefinition);

            return actionDefinitions;
        }
    }
}