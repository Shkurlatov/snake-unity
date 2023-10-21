using UnityEngine;

namespace Snake.Settings
{
    [CreateAssetMenu(menuName = "Settings/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public GameplaySettings GameplaySettings;
        public SnakeSettings SnakeSettings;
    }
}
