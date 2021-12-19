using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpikeSpawn", menuName = "Game/SpikeSpawn")]
public class SpikeSpawn : ScriptableObject
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private int spikeNumber;
    [SerializeField] private float spawnInterval;
    private Queue<GameObject> queue;
    public float SpawnInterval => spawnInterval;

    public void InitQueue()
    {
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
