using ProjectAssets.Scripts.States;
using System;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Scripts.architecture.mvc.player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private ObjectMover _mover;
        [SerializeField] private LivesPanelView _livesPanel;

        [SerializeField] private float _damageCooldown = 0.5f;

        [Inject] private PlayerState _playerState;

        private readonly PlayerModel _model = new();
        private float _horizontalInput;
        private float _lastDamageTime;

        private void Awake()
        {
            _view.OnGrounded += OnGrounded;
            _view.OnObstacleHit += OnObstacleHit;
        }

        private void Start()
        {
            _livesPanel.SetLives(_playerState.LivesCount);
        }

        private void OnGrounded() => _model.IsGrounded = true;

        private void OnObstacleHit()
        {
            if (Time.time - _lastDamageTime < _damageCooldown) return;
            _lastDamageTime = Time.time;

            _playerState.LivesCount = Mathf.Max(0, _playerState.LivesCount - 1);
            _livesPanel.SetLives(_playerState.LivesCount);

            if (_playerState.LivesCount <= 0)
            {
                _view.Stop();
                enabled = false; 
            }
        }

        private void Update()
        {
            _model.Speed = _mover.Speed;
            _model.JumpForce = _mover.JumpForce;

            _horizontalInput = Input.GetAxis("Horizontal");
            _view.Move(_horizontalInput, _model.Speed);

            if (Input.GetKeyDown(KeyCode.Space) && _model.IsGrounded)
            {
                _model.IsGrounded = false;
                _view.Jump(_model.JumpForce);
            }
        }

        private void OnDestroy()
        {
            _view.OnGrounded -= OnGrounded;
            _view.OnObstacleHit -= OnObstacleHit;
        }
    }
}