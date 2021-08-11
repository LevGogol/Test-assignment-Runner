using PathCreation;
using TestAssignment;
using UnityEngine;

namespace TestAssigment
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _mouseSensitive = 0.013f;
        [SerializeField] private float _rotationSensitive = 0.01f;
        [SerializeField] private GameSettings _gameSettings;

        private float _distanceTravelled;
        private float _offset;
        private float _lastMousePositionX;
        private float _cashLastMousePosition;
        private Vector3 _targetPoint;
        private bool _isStop;

        public void Init(PathCreator pathCreator)
        {
            _pathCreator = pathCreator;
            _pathCreator.pathUpdated += TeleportToClosestPoint;
            TeleportToClosestPoint();
        }

        void Update()
        {
            if (_isStop) return;
            
            _distanceTravelled += _speed * Time.deltaTime;
            
            _offset += GetMouseOffset() * _mouseSensitive;
            _offset = Mathf.Clamp(_offset, -_gameSettings.RoadWidth, _gameSettings.RoadWidth);

            var lerpOffset = Mathf.Lerp(transform.position.x, _offset, 0.1f);
            transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled) +
                                 Vector3.right * lerpOffset;

            var rotation = GetMouseOffset() * _rotationSensitive;
            var targetRotation = Quaternion.Euler(0, rotation, 90) *
                                 _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f); ;
            
        }
        
        public void Stop()
        {
            _isStop = true;
        }

        private float GetMouseOffset()
        {
            return Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") / Screen.width : 0;
        }

        private void TeleportToClosestPoint()
        {
            _distanceTravelled = _pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}