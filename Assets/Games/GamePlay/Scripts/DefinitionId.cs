using NUnit.Framework;
using UnityEngine;

namespace GamePlay
{
    public class DefinitionId : MonoBehaviour
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _displayName;

        public string Id { get => _id; set => _id = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
    }
}
