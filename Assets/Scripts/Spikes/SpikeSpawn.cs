using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private IntValue numberOfTriangle;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Vector3Value worldSpawnPosition;
    [SerializeField] private Vector3Value viewPortPosition;
    [SerializeField] private BooleanValue isGameOver;
    [SerializeField] private float speed;
    private Queue<GameObject> spikeQueue;

    private void Awake()
    {
        spikeQueue = new Queue<GameObject>(numberOfTriangle.Int);
        SetWorldSpawnPosition();
        for (var i = 0; i < numberOfTriangle.Int; i++)
        {
            var spike = Instantiate(spikePrefab);
            spike.transform.localPosition = worldSpawnPosition.Vector3;
            spike.SetActive(false);
            spikeQueue.Enqueue(spike);
        }
        StartCoroutine(LaunchSpike());
    }

    private void SetWorldSpawnPosition()
    {
        var temp = Camera.main.ViewportToWorldPoint(viewPortPosition.Vector3);
        temp.z = 0;
        worldSpawnPosition.Vector3 = temp;
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
