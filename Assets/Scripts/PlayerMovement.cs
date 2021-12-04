using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private BooleanValue isOnGround;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveRight();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround.BoolValue) Jump();
    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
        jumpSound.Play();
        isOnGround.BoolValue = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) isOnGround.BoolValue = true;
    }
}
