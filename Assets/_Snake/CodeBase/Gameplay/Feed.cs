using Snake.Player;
using UnityEngine;

namespace Snake.Gameplay
{
    public class Feed : MonoBehaviour
    {
        private IFeedRespawner _respawner;

        public void Initialize(IFeedRespawner respawner)
        {
            _respawner = respawner;
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out SnakeHead snakeHead))
            {
                snakeHead.CollectFeed();
                gameObject.SetActive(false);
                _respawner.RespawnFeed(gameObject);
            }
        }
    }
}