namespace Game.GamePlay
{
    [System.Serializable]
    public class PlayerData
    {
        [UnityEngine.SerializeField]
        private AnimationData _animationData;
        [UnityEngine.SerializeField]
        private MovementData _movementData;
        [UnityEngine.SerializeField]
        private LayerData _layerData;
        public LayerData LayerData => _layerData;
        public AnimationData AnimationData => _animationData;
        public MovementData MovementData => _movementData;
        public void OnInit()
        {
            _animationData.OnInit();
        }
    }
}