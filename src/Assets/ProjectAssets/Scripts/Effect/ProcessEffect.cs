using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectAssets.Scripts.Effect
{
    public sealed class ProcessEffect : MonoBehaviour
    {
        [SerializeField] private Transform _processImage;

        private const float STEP = 1;
        private const float MAX_ANGLE = 360;

        private float _currentAngle = 0;

        private Coroutine _process;
        private bool _isStopped = false;

        private Task _processTask;

        public CancellationTokenSource Cancellation = new CancellationTokenSource();
        
        private void Start()
        {
            _processTask = TaskProcess(); 
        }

        private void Update()
        {
            if (!_isStopped)
            {
                _process = StartCoroutine(Rotate());
            }
            // StartCoroutine(nameof(Rotate));
            // StartCoroutine("Rotate"); not recommended
            // StopAllCoroutines(); не рекомендовано, може зупинити якісь потрібни корутини (if coroutines count > 1)
        }


        public void Stop()
        {
            StopCoroutine(_process);
            // StopCoroutine(Rotate());
            // StopCoroutine(nameof(Rotate));
            // StopCoroutine("Rotate"); not recommended
            _isStopped = true;
        }


        private IEnumerator Rotate()
        {
            // yield return null; // продовження виконання на наступному кадрі
            yield return new WaitForSeconds(1); // пауза на 1 секунду
            // yield return new WaitForSecondsRealtime(1); // пауза на 1 секунду яка не залежить від Time.timeScale

            // yield return new WaitUntil(() => _processTask.IsCompleted || _processTask.IsFaulted || _processTask.IsCanceled); // пауза поки умова не стане true
            // Debug.LogError($"_processTask.IsCompleted: {_processTask.IsCompleted}, _processTask.IsFaulted: {_processTask.IsFaulted}, _processTask.IsCanceled: {_processTask.IsCanceled}");
            
            // yield return new WaitWhile(() => false); // пауза поки умова не стане false like while loop
            // yield return new WaitForEndOfFrame(); // after frame rendering
            // yield return new WaitForFixedUpdate(); // after physics update
            
            _currentAngle += STEP;
            if (_currentAngle > MAX_ANGLE)
            {
                _currentAngle = 0;
            }
            _processImage.transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
        }

        private async Task TaskProcess()
        {
            Debug.LogError("Start task await");
            await Task.Delay(TimeSpan.FromSeconds(5), Cancellation.Token);
            Debug.LogError("Task awaited");
        }
    }
}