using UnityEngine;

namespace Snake.Gameplay
{
    public class Raycaster : MonoBehaviour
    {
        private const string COLLISION_LAYER_NAME = "Apple";

        private int _collisionLayer;

        private void Awake() => 
            _collisionLayer = LayerMask.NameToLayer(COLLISION_LAYER_NAME);

        public Vector3 GetHitPoint()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit)
                && hit.collider.gameObject.layer == _collisionLayer)
            {
                return hit.point;
            }

            return Vector3.zero;
        }
    }
}