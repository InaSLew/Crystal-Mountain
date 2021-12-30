using UnityEngine;

/// <summary>
/// Attached to all 3 different spike variants (triangle, square and icicle).
/// Controls whether to emit IsCollideWithPlayer or not
/// </summary>

public class Spike : MonoBehaviour
{
    [SerializeField] private VoidGameEvent IsCollideWithPlayer;
    [SerializeField] private BooleanValue playerIsOnGround;

    private GameObject player;
    private Collider2D spikeCollider;
    private Collider2D overcomeTrigger;
    private SpriteRenderer spikeRenderer;

    public void OnPlayerIsDead()
    {
        DisableColliderAndTrigger();
        AdjustSpikeAlpha(.3f);
        Invoke(nameof(EnableColliderAndTrigger), 4.5f);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spikeCollider = GetComponent<Collider2D>();
        overcomeTrigger = GetComponentInChildren<Collider2D>();
        spikeRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;
        if (gameObject.CompareTag("TriangleSpike")) IsCollideWithPlayer.Raise(new GenericVoid());
        else if (gameObject.CompareTag("SquareSpike") || gameObject.CompareTag("IcicleSpike"))
        {
            if (IsPlayerAboveSpike()) playerIsOnGround.BoolValue = true;
            else IsCollideWithPlayer.Raise(new GenericVoid());
        }
    }

    private bool IsPlayerAboveSpike()
    {
        var playerLowestColliderBoundOnY = player.GetComponent<Collider2D>().bounds.min.y;
        var spikeHighestOnY = transform.position.y;
        return playerLowestColliderBoundOnY > spikeHighestOnY;
    }
    
    private void DisableColliderAndTrigger()
    {
        spikeCollider.enabled = false;
        overcomeTrigger.enabled = false;
    }

    private void EnableColliderAndTrigger()
    {
        AdjustSpikeAlpha(1f);
        spikeCollider.enabled = true;
        overcomeTrigger.enabled = true;
    }
    
    private void AdjustSpikeAlpha(float value)
    {
        var tmpColor = spikeRenderer.color;
        tmpColor.a = value;
        spikeRenderer.color = tmpColor;
    }
}
