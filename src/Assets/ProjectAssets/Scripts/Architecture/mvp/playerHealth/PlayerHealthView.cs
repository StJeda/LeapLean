using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace ProjectAssets.Scripts.architecture.mvp.playerHealth
{
    public sealed class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Text _healthText;

        private void Awake()
        {
            Assert.IsNotNull(_healthBar);
            Assert.IsNotNull(_healthText);
        }

        public void UpdateHealth(float value)
        {
            // todo: normalize to show in percentage instead of direct value
            _healthBar.value = value;
            _healthText.text = $"HP: {value}";
        }
    }
}