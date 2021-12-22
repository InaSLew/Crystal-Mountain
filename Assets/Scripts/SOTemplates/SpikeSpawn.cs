using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

[CreateAssetMenu(fileName = "SpikeSpawn", menuName = "Game/SpikeSpawn")]
public class SpikeSpawn : ScriptableObject
{
    [Header("Spike to spawn")]
    [SerializeField] private GameObject spikePrefab;
    
    [Header("Number and speed of spawning")]
    [SerializeField] private int minSpikeNumber;
    [SerializeField] private int maxSpikeNumber;
    [SerializeField] private float spawnInterval;

    private int spikeNumber;
    private Queue<GameObject> queue;
    public float SpawnInterval => spawnInterval;

    public void InitQueue()
    {
        spikeNumber = Range(minSpikeNumber, maxSpikeNumber);
        queue = new Queue<GameObject>(spikeNumber);
        for (var i = 0; i < spikeNumber; i++)
        {
            var spike = Instantiate(spikePrefab);
            spike.SetActive(false);
            queue.Enqueue(spike);
        }
    }

    public GameObject Dequeue() => queue.Dequeue();

    public void Enqueue(ref GameObject spike) => queue.Enqueue(spike);
}
