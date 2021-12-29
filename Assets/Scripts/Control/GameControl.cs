using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Random;

/// <summary>
/// The class contains many public exposed methods for listening for game events and reacting upon it
/// </summary>
public class GameControl : MonoBehaviour
{
    [SerializeField] private BooleanValue isGameOver;
    [SerializeField] private VoidGameEvent resetGame;
    
    [Header("Set winning condition")]
    [SerializeField] private List<int> numberTotalSpikeCandidate;
    [SerializeField] private IntValue numberTotalSpike;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (numberTotalSpike != null) numberTotalSpike.Int = numberTotalSpikeCandidate[GetNumberTotalSpike()];
    }

    private int GetNumberTotalSpike() => Range(0, numberTotalSpikeCandidate.Count);

    public void OnPlayerIsDead()
    {
        isGameOver.BoolValue = true;
        player.SetActive(false);
        Invoke(nameof(ResetGame), 3f);
    }

    public void OnPlayerWin()
    {
        player.SetActive(false);
        isGameOver.BoolValue = true;
    }

    public void QuitGame()
    {
        isGameOver.BoolValue = false;
        Application.Quit();
    }
    public void PauseGame() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;
    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void ResetGame()
    {
        isGameOver.BoolValue = false;
        resetGame.Raise(new GenericVoid());
        player.SetActive(true);
    }
}
