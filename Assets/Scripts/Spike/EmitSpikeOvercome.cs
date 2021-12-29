using UnityEngine;

/// <summary>
/// Raises VoidGameEvent when player jumps over a spike
/// </summary>
public class EmitSpikeOvercome : MonoBehaviour
{
    [SerializeField] private VoidGameEvent spikeIsOvercome;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) spikeIsOvercome.Raise(new GenericVoid());
    }
}
