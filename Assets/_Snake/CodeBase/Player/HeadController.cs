using Snake.Input;
using Snake.Settings;
using UnityEngine;

namespace Snake.Player
{
    public class HeadController : MonoBehaviour
    {
        [SerializeField] private Transform _snakeHead;

        private IInputService _input;
        private BodyController _bodyController;
        private float _movementSpeed;
        private float _rotationSpeed;
        private float _bodyOffsetFactor;

        private Vector3 _direction = Vector3.right;
        private Vector3 _targetDirection = Vector3.right;
        private float _updateValue = 0;

        public void Initialize(IInputService inputService, BodyController bodyController, SnakeSettings snakeSettings)
        {
            _input = inputService;
            _bodyController = bodyController;
            _movementSpeed = snakeSettings.MovementSpeed;
            _rotationSpeed = snakeSettings.RotationSpeed;
            _bodyOffsetFactor = snakeSettings.BodyOffsetFactor;

            _bodyController.Initialize(_snakeHead, snakeSettings.InitialBodyCount);
        }

        private void Update()
        {
            MoveHead();
            MoveBody();
        }

        private void FixedUpdate()
        {
            if (_input == null)
            {
                return;
            }

            if (_input.Axis != Vector2.zero)
            {
                _targetDirection = _input.Axis.normalized;
            }
        }

        private void MoveHead()
        {
            _direction = Vector3.MoveTowards(_direction, _targetDirection, _rotationSpeed * Time.deltaTime).normalized;
            transform.Rotate(_movementSpeed * Time.deltaTime * _direction);
            float headAngle = Vector2.Angle(Vector2.up, new Vector2(-_direction.y, _direction.x));
            _snakeHead.localRotation = Quaternion.Euler(new Vector3(0, 0, headAngle * Mathf.Sign(_direction.y)));
        }

        private void MoveBody()
        {
            _updateValue += _bodyOffsetFactor * Time.deltaTime;

            if (_updateValue < 1)
            {
                _bodyController.Tick(_updateValue);
                return;
            }

            _bodyController.UpdateMovementPoints(new Pose(_snakeHead.position, _snakeHead.rotation));
            _updateValue = 0;
            _bodyController.Tick(_updateValue);
        }
    }
}