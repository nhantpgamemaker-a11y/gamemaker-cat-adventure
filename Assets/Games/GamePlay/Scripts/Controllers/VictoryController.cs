using UnityEngine;

namespace Game.GamePlay
{
    public class VictoryController : MonoBehaviour
    {
        private GameManager _gameManager;
        public void Initialize(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerController>(out var playerController))
            {
                _gameManager.HandleVictory();
            }
        }
    }
}
