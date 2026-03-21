using UnityEngine;
using UnityEngine.UI;

namespace CatAdventure.GamePlay
{
    [RequireComponent(typeof(Image))]
    public class ImageHitThreshold : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Image _img;
        [SerializeField] [Range(0f, 1f)]
        private float _defaultThreshold = 0.5f;
        void Start()
        {
            _img.alphaHitTestMinimumThreshold = _defaultThreshold;
        }
    }
}
