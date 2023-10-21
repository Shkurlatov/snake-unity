using UnityEngine;

namespace Snake.Infrastructure
{
    public class GameFactory
    {
        private const string CONTROL_HUD_PATH = "Input/ControlHud";
        private const string FEED_SPAWNER_PATH = "Gameplay/FeedSpawner";
        private const string HEAD_CONTROLLER_PATH = "Player/HeadController";

        public GameObject CreateControlHud() =>
            Instantiate(CONTROL_HUD_PATH);

        public GameObject CreateFeedSpawner() => 
            Instantiate(FEED_SPAWNER_PATH);

        public GameObject CreateHeadController() =>
            Instantiate(HEAD_CONTROLLER_PATH);

        private GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}