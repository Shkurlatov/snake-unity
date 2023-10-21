using Snake.Infrastructure;
using UnityEngine;

namespace Snake.Gameplay
{
    public class FeedSpawner : MonoBehaviour, IFeedRespawner
    {
        [SerializeField] private Raycaster _raycaster;

        private FeedFactory _feedFactory;

        public void Initialize(FeedFactory feedFactory, int feedAmount)
        {
            _feedFactory = feedFactory;

            for (int i = 0; i < feedAmount; i++)
            {
                SpawnNewFeed();
            }
        }

        public void RespawnFeed(GameObject feed)
        {
            Vector3 spawnPoint = GetRandomPosition();

            if (spawnPoint == Vector3.zero)
            {
                Debug.Log("Not enough free space on the Apple");
                return;
            }

            feed.transform.SetPositionAndRotation(spawnPoint, Quaternion.LookRotation(spawnPoint, Vector3.zero));
            feed.SetActive(true);
        }

        private void SpawnNewFeed()
        {
            Vector3 spawnPoint = GetRandomPosition();
            GameObject feed = _feedFactory.CreateFeed(at: spawnPoint);
            feed.GetComponent<Feed>().Initialize(this);
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 spawnPoint;
            int iterationLimit = 100;

            do
            {
                transform.rotation = Random.rotation;
                spawnPoint = _raycaster.GetHitPoint();
            }
            while (spawnPoint == Vector3.zero && iterationLimit-- > 0);

            return spawnPoint;
        }
    }
}