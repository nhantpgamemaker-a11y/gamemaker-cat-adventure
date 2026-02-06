using UnityEngine;

namespace GameMaker.Core.Runtime
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField]
        private DataBootstrapper _gameModuleBootstrapper;
        [SerializeField]
        private CurrencyID _currencyID;
        [SerializeField]
        private PropertyID _propertyID;
        [SerializeField]
        private BundleID _bundleID;
        [SerializeField]
        private ConfigID _configID;
        
        [SerializeField]
        private ActionID _actionID;
        async void Awake()
        {
            bool status = await _gameModuleBootstrapper.BuildAsync();
        }
    }
}
