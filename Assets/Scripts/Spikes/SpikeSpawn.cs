using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private IntValue numberOfTriangle;
    [SerializeField] private float spawnInterval;
    [SerializeField] private BooleanValue isGameOver;
    private Queue<GameObject> spikeQueue;

    private void Awake()
    {
        spikeQueue = new Queue<GameObject>(numberOfTriangle.Int);
        for (var i = 0; i < numberOfTriangle.Int; i++)
        {
            var spike = Instantiate(spikePrefab);
            spike.SetActive(false);
            spikeQueue.Enqueue(spike);
        }
        StartCoroutine(LaunchSpike());
    }

    IEnumerator LaunchSpike()
    {
        while (!isGameOver.BoolValue)
        {
            var spike = spikeQueue.Dequeue();
            spike.transform.position = (Vector2)transform.position;
            spike.SetActive(true);
            spikeQueue.Enqueue(spike);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
