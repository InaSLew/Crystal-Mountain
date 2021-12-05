using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private BooleanValue isOnGround;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // private void FixedUpdate()
    // {
    //     MoveRight();
    // }
    
    // private void MoveRight()
    // {
    //     rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    // }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !isOnGround.BoolValue) return;
        Jump();
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        // rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
        isOnGround.BoolValue = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) isOnGround.BoolValue = true;
    }
}
