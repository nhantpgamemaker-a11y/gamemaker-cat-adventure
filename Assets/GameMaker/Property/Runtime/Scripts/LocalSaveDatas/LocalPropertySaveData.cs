using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameMaker.Core.Runtime;
using Newtonsoft.Json;
using UnityEngine;
namespace GameMaker.Property.Runtime
{
    [System.Serializable]
    public class LocalPropertySaveData : BaseLocalData
    {
        [JsonProperty("PlayerProperties")]
        [SerializeReference]
        private List<PlayerPropertyModel> playerProperties = new();
        public List<PlayerProperty> GetPlayerProperties()
        {
            return playerProperties.Select(x => x.ToPlayerProperty()).ToList();
        }
        public PlayerProperty GetPlayerProperty(string propertyDefinitionId)
        {
            return playerProperties.FirstOrDefault(x => x.GetID() == propertyDefinitionId)?.ToPlayerProperty();
        }
        public async UniTask AddPlayerStat(string statDefinitionId, float value)
        {
            var playerProperty = playerProperties.FirstOrDefault(x => x.GetID() == statDefinitionId);
            if (playerProperty == null)
            {
                var statDefinition = PropertyManager.Instance.GetDefinition(statDefinitionId);
                playerProperties.Add(new PlayerStatModel(statDefinitionId, statDefinition.GetName(), value));
            }
            else
            {
                var playerStat = playerProperty as PlayerStatModel;
                playerStat.AddValue(value);
            }
            await SaveAsync();
        }
        public async UniTask SetPlayerAttribute(string attributeDefinitionId, string value)
        {
            var playerProperty = playerProperties.FirstOrDefault(x => x.GetID() == attributeDefinitionId);
            if (playerProperty == null)
            {
                var attributeDefinition = PropertyManager.Instance.GetDefinition(attributeDefinitionId);
                playerProperties.Add(new PlayerAttributeModel(attributeDefinitionId, attributeDefinition.GetName(), value));
            }
            else
            {
                var playerAttribute = playerProperty as PlayerAttributeModel;
                playerAttribute.SetValue(value);
            }
            await SaveAsync();
        }
    }
    [System.Serializable]
    public abstract class PlayerPropertyModel : PlayerDataModel
    {
        public PlayerPropertyModel(string id, string name) : base(id, name)
        {
        }
        public abstract PlayerProperty ToPlayerProperty();
    }
    [System.Serializable]
    public class PlayerStatModel : PlayerPropertyModel
    {
        [JsonProperty("Value")]
        private float _value;
        public PlayerStatModel(string id, string name, float value) : base(id, name)
        {
            _value = value;
        }
        public void AddValue(float value)
        {
            _value += value;
        }
        public float GetValue()
        {
            return _value;
        }

        public override PlayerProperty ToPlayerProperty()
        {
            var statDefinition = PropertyManager.Instance.GetDefinition(id);
            return new PlayerStat(statDefinition, _value);
        }
    }
    
    [System.Serializable]
    public class PlayerAttributeModel : PlayerPropertyModel
    {
        [JsonProperty("Value")]
        private string _value;
        public PlayerAttributeModel(string id, string name, string value) : base(id, name)
        {
            _value = value;
        }
        public void SetValue(string value)
        {
            _value  =  value;
        }
        public string GetValue()
        {
            return _value;
        }

        public override PlayerProperty ToPlayerProperty()
        {
            var attributeDefinition = PropertyManager.Instance.GetDefinition(id);
            return new PlayerAttribute(attributeDefinition, _value);
        }
    }
}