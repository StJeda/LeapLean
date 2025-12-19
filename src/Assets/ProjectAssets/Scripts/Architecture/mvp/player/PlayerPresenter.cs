using System;
using UnityEngine;

namespace ProjectAssets.Scripts.architecture.mvp.player
{
    public sealed class PlayerPresenter : IDisposable
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;
        
        // 

        public PlayerPresenter(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;

            view.OnInputChanged += HandleMove;
            view.OnJumped += HandleJump;
            view.OnLanded += HandleLanded;
            view.OnObstacleHit += ObstacleHitHandler;
        }

        private void HandleMove(float direction)
        {
            // some combination with other presenters if need
            // check model state gameOver / IsGrounded == false skip moving
            if (_model.IsGrounded)
            {
                _view.Move(direction, _model.Speed);
            }
        }
        
        private void HandleJump()
        {
            if (_model.IsGrounded)
            {
                _model.IsGrounded = false;
                _view.Jump(_model.JumpForce);
            }
        }
        
        private void HandleLanded()
        {
            _model.IsGrounded = true;
        }

        public void ObstacleHitHandler()
        {
            Debug.LogError("Obstacle hit occured");
            // todo: move health damage value to constant
            _model.HealthPoints -= 10;
        }

        public void Dispose()
        {
            _view.OnInputChanged -= HandleMove;
            _view.OnJumped -= HandleJump;
            _view.OnLanded -= HandleLanded;
        }
    }
}