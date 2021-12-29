using System.Collections;
using UnityEngine;

/// <summary>
/// Controls initializing the given spike spawn and the coroutine to launch spikes at player
/// </summary>
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
