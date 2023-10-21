using UnityEngine;

namespace Snake.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        private Transform _target;

        public void Initialize(Transform target) => 
            _target = target;

        private void LateUpdate()
        {
            if (_target == null)
            {
                return;
            }

            transform.rotation = _target.rotation;
        }
    }
}