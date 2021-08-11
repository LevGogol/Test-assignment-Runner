using UnityEngine;

namespace TestAssignment
{
    [CreateAssetMenu]
    public class GameData : ScriptableObject
    {
        public delegate void CoinsChange(int coins);

        public CoinsChange OnCoinsChanged;
        
        [SerializeField] private int _coins;

        public int Coins
        {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
                OnCoinsChanged(_coins);
            }
        }
    }
}