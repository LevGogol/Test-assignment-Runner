using UnityEngine;

namespace TestAssignment
{
    public class Coin : MonoBehaviour
    {
        public delegate void CoinCollected();
        public CoinCollected OnCoinCollected;
        
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private MeshRenderer _meshRenderer;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Player>(out var player))
            {
                _particleSystem.Play();
                OnCoinCollected();
                _meshRenderer.enabled = false;
            }
        }

        private void OnDestroy()
        {
            OnCoinCollected = null;
        }
    }
}
