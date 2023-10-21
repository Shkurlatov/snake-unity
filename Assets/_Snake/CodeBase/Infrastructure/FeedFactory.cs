using UnityEngine;

namespace Snake.Infrastructure
{
    public class FeedFactory
    {
        private const string FEED_CONTAINER_NAME = "FeedContainer";
        private const string FEED_PATH = "Gameplay/Feed";

        private readonly Transform _feedContainer;
        private readonly GameObject _feedPrefab;

        public FeedFactory()
        {
            _feedContainer = new GameObject(FEED_CONTAINER_NAME).transform;
            _feedPrefab = Resources.Load<GameObject>(FEED_PATH);
        }

        public GameObject CreateFeed(Vector3 at) =>
            Object.Instantiate(_feedPrefab, at, Quaternion.LookRotation(at, Vector3.zero), _feedContainer);
    }
}