using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
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
        public string Id { get => _id; set => _id = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
        public List<EnvironmentLayerData> EnvironmentLayers { get => _environmentLayers; set => _environmentLayers = value; }
        public Vector3 PlayerSpawnPoint { get => _playerSpawnPoint; set => _playerSpawnPoint = value; }
        public List<EnvironmentPositionData> EnvironmentPositionDatas { get => _environmentPositionDatas; set => _environmentPositionDatas = value; }
        public List<MonsterPositionData> MonsterPositionData { get => _monsterPositionDatas; set => _monsterPositionDatas = value; }
    }
}
