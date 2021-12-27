using System.Collections;
using UnityEngine;

public class SpikeSpawnView : MonoBehaviour
{
    [Header("Scriptable objects")]
    [SerializeField] private SpikeSpawn spikeSpawn;
    [SerializeField] private BooleanValue isGameOver;

    private void Awake()
    {
        spikeSpawn.InitQueue();
        StartCoroutine(LaunchSpike());
    }

    IEnumerator LaunchSpike()
    {
        while (!isGameOver.BoolValue)
        {
            var spike = spikeSpawn.Dequeue();
            spike.transform.position = (Vector2)transform.position;
            spike.SetActive(true);
            spikeSpawn.Enqueue(ref spike);
            yield return new WaitForSeconds(spikeSpawn.SpawnInterval);
        }
    }

    public void OnResetGame() => StartCoroutine(LaunchSpike());
}
