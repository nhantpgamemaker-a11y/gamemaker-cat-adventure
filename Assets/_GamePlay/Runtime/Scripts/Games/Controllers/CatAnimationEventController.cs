using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class CatAnimationEventController:MonoBehaviour
    {
        [SerializeField] private CatController _catController;
        public void OnAnimationStartEvent()
        {
            _catController.OnAnimationStartEvent();
        }
        public void OnAnimationTransitionEvent()
        {
            _catController.OnAnimationTransitionEvent();
        }
        public void OnAnimationEndEvent()
        {
            _catController.OnAnimationEndEvent();
        }
    }
}
