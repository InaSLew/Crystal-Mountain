using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private IntValue numberOfCrystal;
    [SerializeField] private FloatValue playerDistanceTravelled;
    [SerializeField] private float recycleOffset;
    [SerializeField] private Vector3Value worldSpawnPosition;
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
            worldSpawnPosition.Vector3 += new Vector3(crystal.transform.localScale.x, 0, 0);
            crystalQueue.Enqueue(crystal);
        }
    }
}
