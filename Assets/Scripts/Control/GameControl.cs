using UnityEngine;
using UnityEngine.UI;

// TODO: Make this class smaller
public class GameControl : MonoBehaviour
{
    private GameObject player;
    private GameObject cam;
    private Vector2 playerOriginalPosition;
    private Vector2 cameraOriginalPosition;
    
    // To-be-refactored zone
    private readonly string deathMsg = "YOU DIED :'( RESTART IN 3 seconds...";
    private readonly string winMsg = "YOU WIN :D";
    public Text status;
    // To-be-refactored zone
    
    [SerializeField] private BooleanValue isGameOver;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().ONPlayerWin += ONPlayerWin;
        playerOriginalPosition = player.transform.position;

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cameraOriginalPosition = cam.transform.position;
    }

    public void OnPlayerIsDead()
    {
        isGameOver.BoolValue = true;
        player.SetActive(false);
        status.text = deathMsg;
        Invoke(nameof(ResetGame), 3f);
    }

    private void ONPlayerWin(Player obj)
    {
        player.SetActive(false);
        status.text = winMsg;
    }

    private void ResetGame()
    {
        isGameOver.BoolValue = false;
        player.SetActive(true);
        player.transform.position = playerOriginalPosition;
        cam.transform.position = cameraOriginalPosition;
        status.text = "";
        Time.timeScale = 1;
    }
}
