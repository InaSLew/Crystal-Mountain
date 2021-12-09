using UnityEngine;

public class TriangleSpike : MonoBehaviour
{
    [SerializeField] private Vector3Value spawnPosition;
    [SerializeField] private GameEvent IsSpikeOvercome;
    
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        transform.localPosition = spawnPosition.Vector3;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) IsSpikeOvercome.Raise();
    }
}
