using System;
using UnityEngine;

namespace Snake.Player
{
    public class SnakeHead : MonoBehaviour
    {
        public event Action OnFeedCollected;

        public void CollectFeed() => 
            OnFeedCollected?.Invoke();
    }
}