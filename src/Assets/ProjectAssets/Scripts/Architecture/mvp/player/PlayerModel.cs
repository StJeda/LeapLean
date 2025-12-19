using System;

namespace ProjectAssets.Scripts.architecture.mvp.player
{
    public sealed class PlayerModel
    {
        public float Speed { get; set; } = 100f;
        public float JumpForce { get; set; } = 150f;
        public bool IsGrounded { get; set; }

        private float _healthPoints = 0;

        public float HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                OnHealthPointsChanged?.Invoke(_healthPoints);
            }
        }
        
        public event Action<float> OnHealthPointsChanged;

        public PlayerModel(float healthPoints)
        {
            _healthPoints = healthPoints;
        }
    }
}