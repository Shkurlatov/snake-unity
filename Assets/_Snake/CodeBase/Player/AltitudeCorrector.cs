using UnityEngine;

namespace Snake.Player
{
    public class AltitudeCorrector : MonoBehaviour
    {
        private readonly Vector3 _correctionStep = new Vector3(0, 0, -0.05f);
        private readonly float _minAltitude = 0.55f;
        private readonly float _maxAltitude = 0.75f;

        private void Update() => 
            CorrectAltitude();

        private void CorrectAltitude()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit))
            {
                float altitude = hit.distance;

                if (altitude > _minAltitude && altitude < _maxAltitude)
                {
                    return;
                }

                if (altitude > _maxAltitude)
                {
                    transform.localPosition -= _correctionStep;
                    return;
                }
            }

            transform.localPosition += _correctionStep;
        }
    }
}