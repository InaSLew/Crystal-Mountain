using UnityEngine;

public class EmitSpikeOvercome : MonoBehaviour
{
    [SerializeField] private GameEvent spikeIsOvercome;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) spikeIsOvercome.Raise();
    }
}
