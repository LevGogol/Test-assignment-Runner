using UnityEngine;

namespace TestAssignment
{
    public class Finish : MonoBehaviour
    {
        public delegate void Finished();
        public Finished OnFinish;
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Player>(out var player))
            {
                OnFinish();
                player.Finish();
            }
        }
    }
}
