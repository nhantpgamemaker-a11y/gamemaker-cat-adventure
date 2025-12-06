using Newtonsoft.Json;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class TestLocalData : BaseLocalData
    {
        [JsonProperty("HP")]
        [SerializeField]
        private float _hp = 1;

        [JsonProperty("MP")]
        [SerializeField]
        private float _mp = 1;

        internal override void OnCreate()
        {
            _hp = 2;
            _mp = 4;
        }
    }
}
