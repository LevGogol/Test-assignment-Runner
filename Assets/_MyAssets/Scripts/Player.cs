using System.Threading.Tasks;
using UnityEngine;

namespace TestAssignment
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _forwardSpeed = 5;
        [SerializeField] private float _sideSpeed = 5;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private GameSettings _gameSettings;

        private float _offset;
        
        private readonly float borderOffset = 0.2f;
        private readonly string animationRunKey = "run";
        private readonly string animationFinishKey = "finish";
    
        public void Finish()
        {
            _animator.SetTrigger(animationFinishKey);
        }

        public void MoveForward()
        {
            _animator.SetBool(animationRunKey, true);
            var direction = Vector3.forward * _forwardSpeed;
            _characterController.SimpleMove(direction);
        }

        public void MoveSide(float rightOffset)
        {
            _offset += rightOffset;
            _offset = Mathf.Clamp(_offset, -(_gameSettings.RoadWidth - borderOffset), _gameSettings.RoadWidth - borderOffset);

            _characterController.SimpleMove((_offset - transform.position.x) * _sideSpeed * Vector3.right);
        }

        public void Rotate()
        {
            var targetPoint = new Vector3(_offset, 0, transform.position.z + 1f);
            transform.LookAt(targetPoint);
        }

        public void Stop()
        {
            _animator.SetBool(animationRunKey, false);
        }
    }
}
