using System;
using UnityEngine;

namespace Snake.Settings
{
    [Serializable]
    public class GameplaySettings
    {
        [Range(1, 200)]
        public int FeedAmount;
    }
}
