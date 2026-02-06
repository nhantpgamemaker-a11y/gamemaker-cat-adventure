using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class PropertyID: BaseID
    {
        public PlayerProperty GetPlayerProperty()
        {
            return PropertyGateway.Manager.GetPlayerProperty(this.ID);
        }
        public PlayerStat GetPlayerStat()
        {
            return GetPlayerProperty() as PlayerStat;
        }
        public PropertyDefinition GetPropertyDefinition()
        {
            return PropertyManager.Instance.GetDefinition(ID);
        }
        public PlayerAttribute GetPlayerAttribute()
        {
            return GetPlayerProperty() as PlayerAttribute;
        }
        public async UniTask<bool> AddPropertyAsync(string value, IExtendData extendData)
        {
            return await PropertyGateway.Manager.AddPlayerPropertyAsync(this.ID, value, extendData);
        }
        public async UniTask<bool> SetPropertyAsync(string value, IExtendData extendData)
        {
            return await PropertyGateway.Manager.SetPlayerPropertyAsync(this.ID, value, extendData);
        }
    }
}