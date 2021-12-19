using UnityEngine;

public class TriangleSpike : MonoBehaviour
{
    [SerializeField] private Vector3Value spawnPosition;
    [SerializeField] private GameEvent IsSpikeOvercome;
    
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) IsSpikeOvercome.Raise();
    }
}
