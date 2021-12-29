using UnityEngine;

/// <summary>
/// Draws out spike spawns in editor for easier visualization during development
/// </summary>
public class DrawSpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}
