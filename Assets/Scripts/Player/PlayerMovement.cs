using UnityEngine;

/// <summary>
/// Controls player movement and speed (adjustable through editor)
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Run- and jump-related")]
    [SerializeField] private float speed;
    [SerializeField] private float addOnSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private BooleanValue isOnGround;
    
    [Header("Sound effect")]
    [SerializeField] private AudioSource jumpSound;

    [Header("Needed by spike spawns")]
    [SerializeField] private FloatValue distanceTravelled;
    
    private Rigidbody2D rb;
    private Animator animator;
    private static readonly int IsCrouching = Animator.StringToHash("IsCrouching");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceTravelled.Float = 0;
        animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        MoveRight();
    }
    
    private void MoveRight()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround.BoolValue) Jump();

        if (Input.GetKey(KeyCode.LeftControl) && isOnGround.BoolValue) Crouch();
        else UnCrouch();
        
        distanceTravelled.Float = transform.localPosition.x;
    }

    private void Crouch() => animator.SetBool(IsCrouching, true);
    private void UnCrouch() => animator.SetBool(IsCrouching, false);

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
        isOnGround.BoolValue = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) isOnGround.BoolValue = true;
    }

    public void OnPlayerSpeedUp() => speed += addOnSpeed;
}
