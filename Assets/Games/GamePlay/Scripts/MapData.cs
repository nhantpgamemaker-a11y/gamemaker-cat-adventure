using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class CameraPath
    {
        [UnityEngine.SerializeField]
        private int _index;
        [UnityEngine.SerializeField]
        private List<Vector2> _pathPoints;
        public int Index { get => _index; set => _index = value; }
        public List<Vector2> PathPoints { get => _pathPoints; set => _pathPoints = value; }
        public CameraPath(int index, List<Vector2> pathPoints)
        {
            _index = index;
            _pathPoints = pathPoints;
        }
    }
    [System.Serializable]
    public class CameraData
    {
        [UnityEngine.SerializeField]
        private Vector3 _position;
        [UnityEngine.SerializeField]
        private List<CameraPath> _cameraPaths;

        public Vector3 Position { get => _position; set => _position = value; }
        public List<CameraPath> CameraPaths { get => _cameraPaths; set => _cameraPaths = value; }

        public CameraData(Vector3 position, List<CameraPath> cameraPaths)
        {
            this._position = position;
            this._cameraPaths = cameraPaths;
        }

    }
    [CreateAssetMenu(fileName = "MapData", menuName = "GamePlay/MapData", order = 1)]
    public class MapData : ScriptableObject
    {
        [UnityEngine.SerializeField]
        private string _id;
        [UnityEngine.SerializeField]
        private string _displayName;

        [UnityEngine.SerializeField]
        private Vector3 _playerSpawnPoint;
        [UnityEngine.SerializeField]
        private Vector3 _victoryPoint;
        
        [UnityEngine.SerializeField]
        private List<EnvironmentLayerData> _environmentLayers = new();
        [UnityEngine.SerializeReference]
        private List<EnvironmentPositionData> _environmentPositionDatas = new();
        [UnityEngine.SerializeReference]
        private List<MonsterPositionData> _monsterPositionDatas = new();
        [UnityEngine.SerializeField]
        private CameraData _cameraData;
        public string Id { get => _id; set => _id = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
        public List<EnvironmentLayerData> EnvironmentLayers { get => _environmentLayers; set => _environmentLayers = value; }
        public Vector3 PlayerSpawnPoint { get => _playerSpawnPoint; set => _playerSpawnPoint = value; }
        public List<EnvironmentPositionData> EnvironmentPositionDatas { get => _environmentPositionDatas; set => _environmentPositionDatas = value; }
        public List<MonsterPositionData> MonsterPositionData { get => _monsterPositionDatas; set => _monsterPositionDatas = value; }
        public CameraData CameraData { get => _cameraData; set => _cameraData = value; }
    }
}
