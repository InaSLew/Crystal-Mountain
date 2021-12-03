using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    // private float _jumpVelocity = 10f;
    private Rigidbody2D _rb;
    // private bool _isGround = true;
    // public AudioSource jump;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveRight();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && _isGround) Jump();
    }

    private void MoveRight()
    {
        _rb.velocity = Vector2.right * speed * Time.deltaTime;
    }

    // private void Jump()
    // {
    //     _rb.AddForce(Vector2.up * _jumpVelocity, ForceMode2D.Impulse);
    //     jump.Play();
    //     _isGround = false;
    // }
    //
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     _isGround = true;
    //     if (!other.gameObject.CompareTag("Enemy")) return;
    // }
}
