using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class EnvironmentData
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _displayName;
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private GameObject _editorPrefab;

        public string Id { get => _id; set => _id = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
        public GameObject Prefab { get => _prefab; set => _prefab = value; }
        public GameObject EditorPrefab { get => _editorPrefab; set => _editorPrefab = value; }
    }
}