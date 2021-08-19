using System;
using UnityEngine;

namespace TestAssignment
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Finish _finishPrefab;
        [SerializeField] private Follower _camera;
        [SerializeField] private UI _ui;
        [SerializeField] private float _mouseSensetive;
        
        private MyInput _input;
        private Player _player;
        private Finish _finish;
        private bool isFinished;

        private void Awake()
        {
            Init();
            ResolveDependency();
        }

        private void Init()
        {
            _player = Instantiate(_playerPrefab).GetComponent<Player>();
            _finish = Instantiate(_finishPrefab, _finishPrefab.transform.position, _finishPrefab.transform.rotation).GetComponent<Finish>();
            _input = new MyInput();

        }

        private void ResolveDependency()
        {
            _camera.Init(_player);

            _finish.OnFinish += _player.Finish;
            _finish.OnFinish += _ui.EnableFinalScreen;
            _finish.OnFinish += () => isFinished = true;
        }

        private void Update()
        {
            if(!isFinished)
                ControlPlayer();
        }

        private void ControlPlayer()
        {
            if (_input.IsTouch)
            {
                _player.MoveForward();
                _player.MoveSide(_input.GetMouseOffsetX() * _mouseSensetive);
                _player.Rotate();
            }
            else
            {
                _player.Stop();
            }
        }
    }
}
