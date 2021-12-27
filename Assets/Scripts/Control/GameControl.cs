using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private BooleanValue isGameOver;
    
    private GameObject player;
    private GameObject cam;
    private Vector2 playerOriginalPosition;
    private Vector2 cameraOriginalPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().ONPlayerWin += ONPlayerWin; // <--- Retire target
        playerOriginalPosition = player.transform.position;

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cameraOriginalPosition = cam.transform.position;
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
        player.SetActive(true);
        player.transform.position = playerOriginalPosition;
        cam.transform.position = cameraOriginalPosition;
        // status.text = "";
        Time.timeScale = 1;
    }
}
