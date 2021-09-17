using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 4f;
    private float _jumpVelocity = 15.3f;
    private Rigidbody2D _rb;
    private bool _isGround = true;
    private const float MAXSpeed = 5.5f;
    public AudioSource jump;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveForward();
        if (Input.GetKeyDown(KeyCode.Space) && _isGround) Jump();
    }

    private void MoveForward()
    {
        _rb.AddForce(Vector2.right * _speed, ForceMode2D.Force);
    }

    private void FixedUpdate()
    {
        RegulateToMaxSpeed();
    }

    private void RegulateToMaxSpeed()
    {
        if (_rb.velocity.magnitude > MAXSpeed) _rb.velocity = _rb.velocity.normalized * MAXSpeed;
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpVelocity, ForceMode2D.Impulse);
        jump.Play();
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGround = true;
        if (!other.gameObject.CompareTag("Enemy")) return;
    }
}
