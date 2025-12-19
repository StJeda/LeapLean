using System;
using ProjectAssets.Scripts.States;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Scripts.Behaviors
{
    public sealed class LevelBehavior : MonoBehaviour
    {
        [Inject] private readonly PlayerState _playerState;
        
        private void Awake()
        {
            // read save file from device
            
            // Debug.LogError($"PlayerState is null ? {_playerState == null}");
            
            // show player lives ui
            // show player HP ui
        }
        
        
    }
}