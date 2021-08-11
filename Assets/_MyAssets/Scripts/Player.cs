using System.Threading.Tasks;
using PathCreation;
using TestAssigment;
using UnityEngine;

namespace TestAssignment
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PathFollower _pathFollower;
        [SerializeField] private Animator _animator;
        
        public void Init(PathCreator path)
        {
            _pathFollower.Init(path);
        }

        public async void Finish()
        {
            await Task.Delay(1200);
            _pathFollower.Stop();
            _animator.SetTrigger("finish");
        }
    }
}
