using System;
using UnityEngine;

public class TriangleSpike : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        // probably reset position back to spawn as well
    }
}
