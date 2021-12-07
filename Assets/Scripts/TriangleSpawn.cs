using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private IntValue numberOfTriangle;
    [SerializeField] private float spawnInterval;
    private Vector3 spawnPosition;
    private Queue<GameObject> spikeQueue;

    private void Awake()
    {
        spikeQueue = new Queue<GameObject>(numberOfTriangle.Int);
        spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(2f, .32f, 0));
        spawnPosition.z = 0;
        for (var i = 0; i < numberOfTriangle.Int; i++)
        {
            var spike = Instantiate(spikePrefab);
            spike.transform.localPosition = spawnPosition;
            spike.SetActive(false);
            spikeQueue.Enqueue(spike);
        }

        StartCoroutine(LaunchSpike());
    }

    IEnumerator LaunchSpike()
    {
        for (var i = 0; i < numberOfTriangle.Int; i++)
        {
            var spike = spikeQueue.Dequeue();
            spike.SetActive(true);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
