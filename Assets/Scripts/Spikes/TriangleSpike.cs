using System;
using UnityEngine;

public class TriangleSpike : MonoBehaviour
{
    [SerializeField] private Vector3Value spawnPosition;
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        transform.localPosition = spawnPosition.Vector3;
    }
}
