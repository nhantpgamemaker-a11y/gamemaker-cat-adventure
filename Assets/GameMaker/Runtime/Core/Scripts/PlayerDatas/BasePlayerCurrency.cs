namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class BasePlayerCurrency : BasePlayerData
    {
        private float _value;
        public float Value { get => _value; set => _value = value; }
        public BasePlayerCurrency(string id,IDefinition definition, float value) : base(id, definition)
        {
            _value = value;
        }

        public override object Clone()
        {
            return new BasePlayerCurrency(GetID(),definition, _value);
        }

        public void AddValue(float amount)
        {
            _value += amount;
            NotifyObserver(this);
        }

        public override void CopyFrom(BasePlayerData basePlayerData)
        {
            _value = (basePlayerData as BasePlayerCurrency).Value;
            NotifyObserver(this);
        }
    }
}