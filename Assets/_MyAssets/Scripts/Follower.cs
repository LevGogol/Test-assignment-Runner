using UnityEngine;

namespace TestAssignment
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private bool freezX;

        private Vector3 offset;
        
        public void Init(Player player)
        {
            target = player.transform;
            offset = -transform.position + target.transform.position;
        }

        void LateUpdate()
        {
            var position = target.position;
            if (freezX)
            {
                position.x = 0;
            }

            transform.position = Vector3.Lerp(transform.position, position - offset, 0.1f);
        }
    }
}
