using UnityEngine;
using UnityEngine.UI;

namespace TestAssignment
{
    public class CoinsUI : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameData _gameData;

        private void Start()
        {
            _gameData.OnCoinsChanged += RefreshCoins;
            _text.text = _gameData.Coins.ToString();
        }

        private void OnDestroy()
        {
            _gameData.OnCoinsChanged -= RefreshCoins;
        }

        private void RefreshCoins(int coins)
        {
            _text.text = coins.ToString();
        }
    }
}
