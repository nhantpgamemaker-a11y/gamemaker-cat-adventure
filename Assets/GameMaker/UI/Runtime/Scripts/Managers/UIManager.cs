using UnityEngine;
using GameMaker.Core.Runtime;

namespace GameMaker.UI.Runtime
{
    public class UIManager : ManualMonoSingleton<UIManager>
    {
        [SerializeField]
        private PopupManager _popupManager;
        [SerializeField]
        private ViewManager _viewManager;
        [SerializeField]
        private Camera _uiCamera;
        public PopupManager PopupManager => _popupManager;
        public ViewManager ViewManager => _viewManager;
        public Camera UICamera => _uiCamera;
    }
}
