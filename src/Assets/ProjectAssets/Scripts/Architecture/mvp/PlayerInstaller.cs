using ProjectAssets.Scripts.architecture.mvp.player;
using ProjectAssets.Scripts.architecture.mvp.playerHealth;
using UnityEngine;

namespace ProjectAssets.Scripts.architecture.mvp
{
    public sealed class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerHealthView _playerHealthView;
        
        private PlayerPresenter _playerPresenter;
        private PlayerHealthPresenter _playerHealthPresenter;
        
        // todo:  move to another class for constant values
        private const float MaxHealthPoints = 100f;
        
        private void Awake()
        {
            PlayerModel model = new PlayerModel(MaxHealthPoints);
            _playerPresenter = new PlayerPresenter(model, _playerView);
            _playerHealthPresenter = new PlayerHealthPresenter(model, _playerHealthView);
        }

        private void OnDestroy()
        {
            _playerPresenter?.Dispose();
            _playerHealthPresenter?.Dispose();
        }
    }
}