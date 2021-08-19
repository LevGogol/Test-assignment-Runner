using UnityEngine;

namespace TestAssignment
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private GameObject _coinPrefab;

        private float _step = 15f;
        private int _coinsOnScene = 6;

        private void Start()
        {
            for (int i = 0; i < _coinsOnScene; i++)
            {
                var distance = _step * i;
                SpawnCoin(distance);
            }
        }

        private void SpawnCoin(float distance)
        {
            var xPosition = (_gameSettings.RoadWidth - 1f) * Random.Range(-1f, 1f);
            var spawnPosition = new Vector3(xPosition, 1f, distance);
            var coin = Instantiate(_coinPrefab, spawnPosition, Quaternion.identity, transform).GetComponent<Coin>();
            coin.OnCoinCollected += () =>
            {
                _gameData.Coins++;
                _gameData.OnCoinsChanged(_gameData.Coins);
            };
        }
    }
}