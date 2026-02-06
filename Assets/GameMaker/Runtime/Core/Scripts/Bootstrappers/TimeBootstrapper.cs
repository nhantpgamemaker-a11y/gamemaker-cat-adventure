using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    public class TimeBootstrapper : MonoBehaviour
    {
        public async UniTask<bool> BuildAsync()
        {
            bool status = true;
            return status;
        }
    }
}
