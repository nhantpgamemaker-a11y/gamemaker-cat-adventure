using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    public class LocalDataLoader : MonoBehaviour
    {
        [SerializeField]
        private TestLocalData testLocalData;
        public void Awake()
        {
            _ = AwakeAsync();
        }
        public async UniTask AwakeAsync()
        {
            await LocalDataManager.Instance.InitAsync();
            testLocalData = LocalDataManager.Instance.Get<TestLocalData>() as TestLocalData;
        }
        [ContextMenu("Save Data")]
        public void Save()
        {
            _ = testLocalData.SaveAsync();
        }
    }
}
