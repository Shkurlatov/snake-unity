using System;
using UnityEngine;

namespace Snake.Settings
{
    [Serializable]
    public class SnakeSettings
    {
        [Range(5, 30)]
        public float MovementSpeed;

        [Range(2, 20)]
        public float RotationSpeed;

        [Range(2, 10)]
        public float BodyOffsetFactor;

        [Range(1, 10f)]
        public int InitialBodyCount;
    }
}
