using UnityEngine;

namespace ProjectAssets.Scripts.Effect
{
    public sealed class StopProcess : MonoBehaviour
    {
        [SerializeField] private ProcessEffect _process;
        
        public void Execute()
        {
            Debug.LogError("StopProcess.Execute");
            _process.Cancellation.Cancel();
        }
    }
}