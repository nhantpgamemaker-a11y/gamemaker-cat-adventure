using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(DefinitionId))]
    public class EnvironmentControllerEditor : PositionControllerEditor
    {
        private DefinitionId _definitionID;
        public DefinitionId DefinitionID
        {
            get
            {
                if (_definitionID == null)
                {
                    _definitionID = GetComponent<DefinitionId>();
                }
                return _definitionID;
            }
        }
        public string GetDefinitionID()
        {
            return DefinitionID.Id;
        }
        public EnvironmentPositionData GetEnvironmentData()
        {
            var layerControllerEditor = GetLayerControllerEditor();
            return new EnvironmentPositionData(GetPosition(),
            GetScale(),
            GetDefinitionID(),
            layerControllerEditor.GetZIndex());
        }
    }
}
