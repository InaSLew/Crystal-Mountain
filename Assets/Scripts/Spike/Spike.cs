using UnityEngine;

/// <summary>
/// Attached to all 3 different spike variants (triangle, square and icicle).
/// Controls whether to emit IsCollideWithPlayer or not
/// </summary>

public class Spike : MonoBehaviour
{
    [SerializeField] private GameEvent IsCollideWithPlayer;
    [SerializeField] private BooleanValue playerIsOnGround;

    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;
        if (gameObject.CompareTag("TriangleSpike")) IsCollideWithPlayer.Raise();
        else if (gameObject.CompareTag("SquareSpike") || gameObject.CompareTag("IcicleSpike"))
        {
            if (IsPlayerAboveSpike()) playerIsOnGround.BoolValue = true;
            else IsCollideWithPlayer.Raise();
        }
    }

    private bool IsPlayerAboveSpike()
    {
        var playerSprite = player.GetComponent<SpriteRenderer>();
        var playerLowestBoundOnY = player.transform.position.y - playerSprite.bounds.min.y / 2;
        var spikeHighestOnY = transform.position.y;
        
        return playerLowestBoundOnY > spikeHighestOnY;
    }
}
