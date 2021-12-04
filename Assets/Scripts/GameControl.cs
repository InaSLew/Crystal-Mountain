using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int totalAttempts = 0;
    private GameObject player;
    private GameObject cam;
    private Vector2 playerOriginalPosition;
    private Vector2 cameraOriginalPosition;
    private readonly string deathMsg = "YOU DIED :'( RESTART IN 3 seconds...";
    private readonly string winMsg = "YOU WIN :D";
    
    public Text numberFailAttempts;
    public Text status;
    public AudioSource death;
    public AudioSource throughTheGate;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().ONPlayerDeath += ONPlayerDeath;
        player.GetComponent<Player>().ONPlayerWin += ONPlayerWin;
        playerOriginalPosition = player.transform.position;

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cameraOriginalPosition = cam.transform.position;

        numberFailAttempts.text = totalAttempts.ToString();
    }

    private void ONPlayerDeath(Player obj)
    {
        death.Play();
        player.SetActive(false);
        status.text = deathMsg;
        totalAttempts += 1;
        numberFailAttempts.text = totalAttempts.ToString();
        Invoke(nameof(ResetGame), 3f);
    }

    private void ONPlayerWin(Player obj)
    {
        throughTheGate.Play();
        player.SetActive(false);
        status.text = winMsg;
    }

    private void ResetGame()
    {
        player.SetActive(true);
        player.transform.position = playerOriginalPosition;
        cam.transform.position = cameraOriginalPosition;
        status.text = "";
        Time.timeScale = 1;
    }
}
