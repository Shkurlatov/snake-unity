using Snake.Settings;
using UnityEngine;

namespace Snake.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] GameSettings _gameSettings;

        private Game _game;

        private void Awake()
        {
            _game = new Game(_gameSettings);
            DontDestroyOnLoad(this);
        }
    }
}