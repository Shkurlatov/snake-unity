using UnityEngine;

namespace Snake.Infrastructure
{
    public class BodyFactory
    {
        private const string BODY_CONTAINER_NAME = "SnakeBody";
        private const string BODY_PART_PATH = "Player/SnakeBody";

        private readonly Transform _bodyContainer;
        private readonly GameObject _snakeBodyPrefab;

        public BodyFactory()
        {
            _bodyContainer = new GameObject(BODY_CONTAINER_NAME).transform;
            _snakeBodyPrefab = Resources.Load<GameObject>(BODY_PART_PATH);
        }

        public GameObject CreateBodySegment(Pose at) =>
            Object.Instantiate(_snakeBodyPrefab, at.position, at.rotation, _bodyContainer);
    }
}