using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField] private BooleanValue isGameOver;
    [SerializeField] private GameEvent resetGame;

    // private readonly int FinishScene = 2;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnPlayerIsDead()
    {
        isGameOver.BoolValue = true;
        player.SetActive(false);
        Invoke(nameof(ResetGame), 3f);
    }

    public void OnPlayerWin() => player.SetActive(false);

    public void QuitGame() => Application.Quit();
    public void PauseGame() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;
    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    // public void LoadFinishScene() => SceneManager.LoadScene(FinishScene);

    private void ResetGame()
    {
        isGameOver.BoolValue = false;
        resetGame.Raise();
        player.SetActive(true);
    }
}
