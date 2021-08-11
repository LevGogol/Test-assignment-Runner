using PathCreation;
using UnityEngine;

namespace TestAssignment
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Follower _camera;
        [SerializeField] private PathCreator _path;

        private void Awake()
        {
            var player = Instantiate(_playerPrefab).GetComponent<Player>();
            player.Init(_path);
            
            _camera.Init(player);
        }
    }
}
