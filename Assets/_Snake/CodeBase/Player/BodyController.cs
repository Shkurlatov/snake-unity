using Snake.Infrastructure;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Player
{
    public class BodyController
    {
        private readonly BodyFactory _bodyFactory;
        private readonly List<SnakeBody> _bodySegments;

        public BodyController(BodyFactory bodyFactory)
        {
            _bodyFactory = bodyFactory;
            _bodySegments = new List<SnakeBody>();
        }

        public void Initialize(Transform snakeHead, int initialBodyCount)
        {
            Pose initialPoint = new Pose(snakeHead.position, snakeHead.rotation);

            for (int i = 0; i < initialBodyCount; i++)
            {
                AddBodySegment(initialPoint);
            }

            UpdateMovementPoints(initialPoint);
            snakeHead.GetComponent<SnakeHead>().OnFeedCollected += GrowSnake;
        }

        public void Tick(float updateValue)
        {
            foreach (SnakeBody segment in _bodySegments)
            {
                segment.Move(updateValue);
            }
        }

        public void UpdateMovementPoints(Pose targetPoint)
        {
            foreach (SnakeBody segment in _bodySegments)
            {
                targetPoint = segment.ReplaceTargetPoint(targetPoint);
            }
        }

        private void GrowSnake()
        {
            Transform lastSegment = _bodySegments[^1].transform;
            Pose initialPoint = new Pose(lastSegment.position, lastSegment.rotation);
            AddBodySegment(initialPoint);
        }

        private void AddBodySegment(Pose initialPoint)
        {
            SnakeBody bodySegment = _bodyFactory.CreateBodySegment(at: initialPoint).GetComponent<SnakeBody>();
            _bodySegments.Add(bodySegment);
        }
    }
}