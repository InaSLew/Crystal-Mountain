using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private IntValue numberOfTriangle;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Vector3Value spawnPosition;
    [SerializeField] private BooleanValue isGameOver;
    private Queue<GameObject> spikeQueue;

    private void Awake()
    {
        spikeQueue = new Queue<GameObject>(numberOfTriangle.Int);
        var temp = Camera.main.ViewportToWorldPoint(new Vector3(2f, .32f, 0));
        temp.z = 0;
        spawnPosition.Vector3 = temp;
        for (var i = 0; i < numberOfTriangle.Int; i++)
        {
            var spike = Instantiate(spikePrefab);
            spike.transform.localPosition = spawnPosition.Vector3;
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
            spike.SetActive(true);
            spikeQueue.Enqueue(spike);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
