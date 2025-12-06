using Cysharp.Threading.Tasks;
using GameMaker.UI.Runtime;
using UnityEngine;

namespace GameMaker.UI.Test
{
    public class View02 : BaseView
    {
        public static async UniTask ShowViewAsync()
        {
            await UIManager.Instance.ViewManager.ShowAsync("View02");
        }
    }
}
