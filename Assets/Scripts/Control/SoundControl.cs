using UnityEngine;

/// <summary>
/// Plays the sound effects and the background music
/// </summary>
public class SoundControl : MonoBehaviour
{
    [Header("Audio source files")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioSource playerThroughGate;

    private void PlayDeath() => playerDeath.Play();
    private void PlayThroughGate() => playerThroughGate.Play();

    public void OnPlayerDeath() => PlayDeath();
    public void OnPlayerThroughGate() => PlayThroughGate();
}
