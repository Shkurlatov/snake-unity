using UnityEngine;

namespace Snake.Player
{
    public class SnakeBody : MonoBehaviour
    {
        private Pose _initialPoint;
        private Pose _targetPoint;

        private void Awake()
        {
            _targetPoint = new Pose(transform.position, transform.rotation);
            _initialPoint = _targetPoint;
        }

        public void Move(float updateValue) => 
            transform.SetPositionAndRotation(
                Vector3.Lerp(_initialPoint.position, _targetPoint.position, updateValue),
                Quaternion.Lerp(_initialPoint.rotation, _targetPoint.rotation, updateValue));

        public Pose ReplaceTargetPoint(Pose targetPoint)
        {
            _initialPoint = _targetPoint;
            _targetPoint = targetPoint;
            return _initialPoint;
        }
    }
}