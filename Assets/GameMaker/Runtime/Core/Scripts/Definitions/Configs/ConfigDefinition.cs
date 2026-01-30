namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class ConfigDefinition : Definition
    {
        private string _value;
        public string Value { get => _value; set => _value = value; }
        public ConfigDefinition() : base()
        {
            
        }
        public ConfigDefinition(string id, string name, string value): base(id, name)
        {
            _value = value;
        }
        public override object Clone()
        {
            return new ConfigDefinition(GetID(), GetName(), _value);
        }
    }
}
