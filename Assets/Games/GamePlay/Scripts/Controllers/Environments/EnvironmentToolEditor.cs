using System.Collections.Generic;
using System.Linq;
using GamePlay;
using UnityEngine;

namespace Game.GamePlay
{
    public class EnvironmentToolEditor : MonoBehaviour
    {
        [SerializeField] private MapData _mapData;
        [SerializeField] private DefinitionId[] _environmentControllerEditorPrefab;
        [SerializeField] private LayerControllerEditor _layerControllerEditorPrefab;

        [ContextMenu("Load Map Data")]
        public void LoadMapData()
        {
            var layerControllerEditors = GetComponentsInChildren<LayerControllerEditor>().ToList();
            foreach (var tran in layerControllerEditors)
            {
                DestroyImmediate(tran.gameObject);
            }
            foreach (var environmentLayerData in _mapData.EnvironmentLayers)
            {
                var layerControllerEditor = Instantiate(_layerControllerEditorPrefab, this.transform);
                layerControllerEditor.transform.localScale = environmentLayerData.Scale;
                layerControllerEditor.transform.position = new Vector3(0, 0, environmentLayerData.ZIndex);
                layerControllerEditor.SetSortingOrder((int)environmentLayerData.ZIndex);

                foreach (var environmentPositionData in _mapData.EnvironmentPositionDatas)
                {
                    if (environmentPositionData.LayerIndex != environmentLayerData.ZIndex) continue;
                    var environmentDefinitionId = environmentPositionData.ReferenceID;
                    var environmentPrefab = System.Array.Find(_environmentControllerEditorPrefab,
                        prefab => prefab.Id == environmentDefinitionId);
                    if (environmentPrefab == null) continue;

                    var environmentControllerEditor = Instantiate(environmentPrefab.gameObject,
                        layerControllerEditor.transform);
                    environmentControllerEditor.transform.position = new Vector3(
                        environmentPositionData.Position.x,
                        environmentPositionData.Position.y,
                        environmentLayerData.ZIndex);
                    environmentControllerEditor.transform.localScale = environmentPositionData.Scale;
                }
            }
        }
        [ContextMenu("Save Map Data")]
        public void SaveMapData()
        {
            var layerControllerEditors = GetComponentsInChildren<LayerControllerEditor>();
            var layerEnvironmentDataList = new List<EnvironmentLayerData>();
            var environmentDataList = new List<EnvironmentPositionData>();
            foreach (var layerControllerEditor in layerControllerEditors)
            {
                layerEnvironmentDataList.Add(new EnvironmentLayerData(
                    layerControllerEditor.GetScale(),
                    layerControllerEditor.GetZIndex()
                ));

                var environmentControllerEditors = layerControllerEditor.GetComponentsInChildren<EnvironmentControllerEditor>();
                foreach (var environmentControllerEditor in environmentControllerEditors)
                {
                    environmentDataList.Add(environmentControllerEditor.GetEnvironmentData());
                }
            }
            _mapData.EnvironmentLayers = layerEnvironmentDataList;
            _mapData.EnvironmentPositionDatas = environmentDataList;
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(_mapData);
#endif
        }
    }
}
