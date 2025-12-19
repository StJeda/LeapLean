using System;
using ProjectAssets.Scripts.architecture.mvp.player;
using UnityEngine;

namespace ProjectAssets.Scripts.architecture.mvp.playerHealth
{
    public sealed class PlayerHealthPresenter : IDisposable
    {
        private readonly PlayerHealthView _view;
        private readonly PlayerModel _playerModel;
        public PlayerHealthPresenter(PlayerModel model, PlayerHealthView view)
        {
            _playerModel = model;
            _view = view;
            _playerModel.OnHealthPointsChanged += HealthPointsChangedHandler;
        }

        private void HealthPointsChangedHandler(float healthPoints)
        {
            Debug.LogError($"Got health points update, current HP is {healthPoints}");
            _view.UpdateHealth(healthPoints);
            // update view
        }
        
        public void Dispose()
        {
            _playerModel.OnHealthPointsChanged -= HealthPointsChangedHandler;
        }
    }
}