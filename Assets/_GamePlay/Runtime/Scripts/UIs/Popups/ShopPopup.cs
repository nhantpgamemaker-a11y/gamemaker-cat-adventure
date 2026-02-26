using System;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using GameMaker.UI.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace CatAdventure.GamePlay
{
    public class ShopPopup : BasePopup
    {
        public const string POPUP_NAME = "ShopPopup";
        [SerializeField] private Button _btnClose;
        [SerializeField] private UICurrency[] _uICurrencies;
        protected override void OnShow()
        {
            base.OnShow();
            foreach (var uiCurrency in _uICurrencies)
            {
                uiCurrency.Init();
            }
        }
        protected override void OnShown()
        {
            base.OnShown();
            _btnClose.onClick.AddListener(OnClickClose);
        }
        protected override void OnHide()
        {
            base.OnHide();
            _btnClose.onClick.RemoveListener(OnClickClose);
             foreach (var uiCurrency in _uICurrencies)
            {
                uiCurrency.Clear();
            }
        }
        private void OnClickClose()
        {
            popupController.HideAsync(this).Forget();
        }
    }
}
