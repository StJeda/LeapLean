using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform wallLeft;
    [SerializeField] private Transform wallRight;
    [SerializeField] private float padding = 50f;
    [SerializeField] private float speed = 100f;

    private Rigidbody2D _rb;
    private float _minX;
    private float _maxX;
    private int _dir = 1;

    private Vector2 _lastPos;
    private Vector2 _delta;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.gravityScale = 0f;
    }

    private void Start()
    {
        _minX = wallLeft.position.x + padding;
        _maxX = wallRight.position.x - padding;
        if (_minX > _maxX) (_minX, _maxX) = (_maxX, _minX);

        _lastPos = _rb.position;
    }

    private void FixedUpdate()
    {
        Vector2 pos = _rb.position;

        pos.x += _dir * speed * Time.fixedDeltaTime;

        if (pos.x <= _minX) { pos.x = _minX; _dir = 1; }
        if (pos.x >= _maxX) { pos.x = _maxX; _dir = -1; }

        _rb.MovePosition(pos);

        
        _delta = pos - _lastPos;
        _lastPos = pos;
    }

    private void OnCollisionStay2D(Collision2D c)
    {
        if (!c.collider.CompareTag("Player")) return;

       
        bool playerOnTop = false;
        for (int i = 0; i < c.contactCount; i++)
        {
            if (c.GetContact(i).normal.y > 0.5f) { playerOnTop = true; break; }
        }
        if (!playerOnTop) return;

        var prb = c.collider.attachedRigidbody;
        if (prb != null)
            prb.MovePosition(prb.position + _delta);
        else
            c.transform.position += (Vector3)_delta;
    }
}
