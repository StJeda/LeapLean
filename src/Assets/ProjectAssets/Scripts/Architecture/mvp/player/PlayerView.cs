using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectAssets.Scripts.architecture.mvp.player
{
    public sealed class PlayerView : MonoBehaviour
    {
        public event Action<float> OnInputChanged;
        public event Action OnJumped;
        public event Action OnLanded;
        public event Action OnObstacleHit;
        
        [SerializeField] private Rigidbody2D _rb;

        private float _horizontalInput = 0;

        private void Awake()
        {
            Assert.IsNotNull(_rb, "Rigidbody2D is required");
        }
        
        private void Update()
        {
            // get horizontal direction 1 - move right; -1 - move left
            _horizontalInput = Input.GetAxis("Horizontal");
            OnInputChanged?.Invoke(_horizontalInput);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumped?.Invoke();
            }
        }
        
        public void Move(float horizontalInput, float speed)
        {
            _rb.linearVelocityX = horizontalInput * speed;
        }

        public void Jump(float jumpForce)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                OnLanded?.Invoke();
            }
            
            if (other.gameObject.CompareTag("Obstacle"))
            {
                OnObstacleHit?.Invoke();
            }
        }
    }
}