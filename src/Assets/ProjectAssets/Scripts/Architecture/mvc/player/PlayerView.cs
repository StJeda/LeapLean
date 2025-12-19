using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectAssets.Scripts.architecture.mvc.player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        public event Action OnGrounded;
        public event Action OnObstacleHit;

        private void Awake()
        {
            Assert.IsNotNull(_rb, "Rigidbody2D is required");
        }

        public void Move(float horizontalInput, float speed)
        {
            _rb.linearVelocityX = horizontalInput * speed;
        }

        public void Jump(float jumpForce)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        public void Stop()
        {
            _rb.linearVelocity = Vector2.zero;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
                OnGrounded?.Invoke();

            if (other.gameObject.CompareTag("Obstacle"))
                OnObstacleHit?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
                OnObstacleHit?.Invoke();
        }
    }
}