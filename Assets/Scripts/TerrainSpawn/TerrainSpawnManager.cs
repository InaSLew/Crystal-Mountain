using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns the crystal ground and keeps it moving through queuing and dequeuing from the spike queue.
/// </summary>
public class TerrainSpawnManager : MonoBehaviour
{
    [Header("Crystal prefab and how many to spawn")]
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private IntValue numberOfCrystal;
    
    [Header("Endless-scrolling-related")]
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private FloatValue playerDistanceTravelled;
    [SerializeField] private float recycleOffset;
    
    private Vector3 worldSpawnPosition;
    private Queue<GameObject> crystalQueue;
    private Vector3 nextPosition;

    void Awake()
    {
        crystalQueue = new Queue<GameObject>(numberOfCrystal.Int);
        nextPosition = startPosition;
        for (var i = 0; i < numberOfCrystal.Int; i++)
        {
            var crystal = Instantiate(crystalPrefab);
            crystal.transform.localPosition = nextPosition;
            nextPosition.x += crystal.transform.localScale.x;
            crystalQueue.Enqueue(crystal);
        }
    }

    private void Update()
    {
        if (crystalQueue.Peek().transform.localPosition.x + recycleOffset < playerDistanceTravelled.Float)
        {
            var crystal = crystalQueue.Dequeue();
            crystal.transform.localPosition = nextPosition;
            nextPosition.x += crystal.transform.localScale.x;
            worldSpawnPosition += new Vector3(crystal.transform.localScale.x, 0, 0);
            crystalQueue.Enqueue(crystal);
        }
    }
}
