using UnityEngine;

public class ObjectMover: MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 200f;
    [field: SerializeField] public float JumpForce { get; private set; } = 400f;

}
