using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private float proportionToReposition;
    private BoxCollider2D boxCollider;
    private float horizontalBorder;
    private readonly Vector2 offset = Vector2.right * 5f;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        horizontalBorder = boxCollider.size.x;
    }

    private void Update()
    {
        if (transform.position.x < -(horizontalBorder * proportionToReposition)) Reposition();
    }

    private void Reposition()
    {
        transform.position += (Vector3)offset;
        // var transform1 = transform;
        // transform1.position = (Vector2) transform1.position + offset;
    }
}
