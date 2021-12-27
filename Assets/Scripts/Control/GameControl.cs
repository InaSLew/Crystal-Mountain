using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private BooleanValue isGameOver;
    [SerializeField] private GameEvent resetGame;
    
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().ONPlayerWin += ONPlayerWin; // <--- Retire target
    }

    public void OnPlayerIsDead()
    {
        isGameOver.BoolValue = true;
        player.SetActive(false);
        Invoke(nameof(ResetGame), 3f);
    }

    // Retire target
    private void ONPlayerWin(Player obj)
    {
        player.SetActive(false);
        // status.text = winMsg;
    }

    private void ResetGame()
    {
        isGameOver.BoolValue = false;
        resetGame.Raise();
        player.SetActive(true);
    }
}
