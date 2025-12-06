using Cysharp.Threading.Tasks;
using LitMotion.Animation;
using UnityEngine;

namespace GameMaker.UI.Runtime
{
    public class UIAnimation : MonoBehaviour
    {
        [SerializeField] private LitMotionAnimation _showAnimation;
        [SerializeField] private LitMotionAnimation _hideAnimation;


        public async UniTask ShowAsync()
        {
            _hideAnimation?.Stop();
            _showAnimation?.Play();
            await UniTask.WaitUntil(() => !_showAnimation.IsPlaying);
        }
        public async UniTask HideAsync()
        {
            _showAnimation?.Stop();
            _hideAnimation?.Play();
            await UniTask.WaitUntil(() => !_hideAnimation.IsPlaying);
        }
    }
}