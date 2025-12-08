using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace GameMaker.UI.Runtime
{
    public enum ViewShowType
    {
        Parallel,
        Before,
        After
    }
    public class ViewManager : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        private BaseView _currentView;
        private Dictionary<string, BaseView> _viewCacheDict = new();
        public BaseView CurrentView => _currentView;
        public async UniTask ShowAsync(string viewName,ViewShowType viewShowType = ViewShowType.Parallel, object data = null)
        {
            var newView = await GetViewAsync(viewName);
            if (newView == _currentView) return;
            newView.SetData(data);
            if (viewShowType == ViewShowType.Parallel)
            {
                var tasks = new List<UniTask>(2);
                if (_currentView != null)
                {
                    tasks.Add(_currentView.HideAsync());
                }
                tasks.Add(newView.ShowAsync());
                await UniTask.WhenAll(tasks);
            }
            else if (viewShowType == ViewShowType.Before)
            {
                await newView.ShowAsync();
                if(_currentView != null)
                {
                   await _currentView.HideAsync();
                }
            }
            else
            {
                if(_currentView != null)
                {
                    await _currentView.HideAsync();
                }
                
                await newView.ShowAsync();
            }
            
            _currentView = newView;
        }
        private async UniTask<BaseView> GetViewAsync(string viewName)
        {
            if (_viewCacheDict.TryGetValue(viewName, out BaseView baseView))
            {
                return baseView;
            }
            var loadAsyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(viewName);
            var viewObjectPrefab = await UniTask.RunOnThreadPool(async () => await loadAsyncOperationHandle.ToUniTask());
            var baseViewPrefab = viewObjectPrefab.GetComponent<BaseView>();
            await UniTask.SwitchToMainThread();
            baseView = Instantiate(baseViewPrefab, _canvas.transform);
            _viewCacheDict[viewName] = baseView;
            return baseView;
        }
    }
}