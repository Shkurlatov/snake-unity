using Snake.Gameplay;
using Snake.Input;
using Snake.Player;
using Snake.Settings;
using UnityEngine;

namespace Snake.Infrastructure
{
    public class Game
    {
        private readonly GameSettings _gameSettings;
        private readonly IInputService _input;
        private readonly GameFactory _gameFactory;

        private FeedSpawner _feedSpawner;
        private HeadController _headController;

        public Game(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _input = new MobileInputService();
            _gameFactory = new GameFactory();

            InitGameplay();
            InitSnake();
            InitCamera();

            StartGame();
        }

        private void InitGameplay()
        {
            InitControlHud();
            InitFeedSpawner();
        }

        private void InitControlHud() =>
            _gameFactory.CreateControlHud();

        private void InitFeedSpawner()
        {
            _feedSpawner = _gameFactory.CreateFeedSpawner().GetComponent<FeedSpawner>();
            _feedSpawner.Initialize(new FeedFactory(), _gameSettings.GameplaySettings.FeedAmount);
        }

        private void InitSnake()
        {
            BodyController bodyController = new BodyController(new BodyFactory());
            GameObject headController = _gameFactory.CreateHeadController();
            _headController = headController.GetComponent<HeadController>();
            _headController.Initialize(_input, bodyController, _gameSettings.SnakeSettings);
        }

        private void InitCamera()
        {
            CameraController camera = Object.FindAnyObjectByType<CameraController>();
            camera.Initialize(_headController.transform);
        }

        private void StartGame() => 
            _headController.enabled = true;
    }
}