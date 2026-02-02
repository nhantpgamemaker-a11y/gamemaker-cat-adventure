namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public class PlayerPropertyManager : PlayerDataManager
    {
        public PlayerProperty GetProperty(string referenceId)
        {
            return GetPlayerData(referenceId) as PlayerProperty;
        }
        public void AddObserver(IObserverWithScope<PlayerProperty, string> observer, string[] scopes)
        {
            AddObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public void RemoveObserver(IObserverWithScope<PlayerProperty, string> observer, string[] scopes)
        {
            RemoveObserver((IObserverWithScope<BasePlayerData, string>)observer, scopes);
        }
        public void AddStat(string id, long value)
        {
            var playerProperty = GetPlayerData(id);
            var playerStat = playerProperty as PlayerStat;
            playerStat.AddValue(value);
        }
        public void SetStat(string id, long value)
        {
            var playerProperty = GetPlayerData(id);
            var playerStat = playerProperty as PlayerStat;
            playerStat.SetValue(value);
        }
        public void SetAttribute(string id, string value)
        {
            var playerProperty = GetPlayerData(id);
            var playerAttribute = playerProperty as PlayerAttribute;
            playerAttribute.SetValue(value);
        }
    }
}