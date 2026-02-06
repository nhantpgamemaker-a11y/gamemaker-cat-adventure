using System.Linq;

namespace GameMaker.Core.Runtime
{
    public enum ConsumeType
    {
        Add= 0 ,
        Set = 1
    }
    public class StatReceiverProduct : BaseReceiverProduct
    {
        private float _value;
        private ConsumeType _consumeType;
        public float Value => _value;
        public ConsumeType ConsumeType => _consumeType;
        public StatReceiverProduct(string id, float value, ConsumeType consumeType) : base(id)
        {
            _value = value;
            _consumeType = consumeType;
        }
        public override void Consume(PlayerDataManager[] playerDataManagers, IExtendData extendData)
        {
           var playerPropertyDataManager = playerDataManagers.FirstOrDefault(x => x.GetType() == typeof(PlayerPropertyManager)) as PlayerPropertyManager;
            switch (ConsumeType)
                {
                    case ConsumeType.Add:
                        playerPropertyDataManager.Add(ID,Value.ToString());
                        RuntimeActionManager.Instance.NotifyAction(PropertyActionData.ADD_PROPERTY_ACTION_DEFINITION, new PropertyActionData(ID,Value.ToString(), extendData));
                        break;
                    case ConsumeType.Set:
                        playerPropertyDataManager.Set(ID,Value.ToString());
                        RuntimeActionManager.Instance.NotifyAction(PropertyActionData.SET_PROPERTY_ACTION_DEFINITION, new PropertyActionData(ID,Value.ToString(), extendData));
                        break;
                }
        }
    }
}