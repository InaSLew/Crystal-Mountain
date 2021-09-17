using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int _totalAttempts = 0;
    private GameObject _player;
    private GameObject _camera;
    private Vector2 _playerOriginalPosition;
    private Vector2 _cameraOriginalPosition;
    private string _deathMsg = "YOU DIED :'( RESTART IN 3 seconds...";
    private string _winMsg = "YOU WIN :D";
    
    public Text numberFailAttempts;
    public Text status;
    public AudioSource death;
    public AudioSource throughTheGate;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.GetComponent<Player>().ONPlayerDeath += ONPlayerDeath;
        _player.GetComponent<Player>().ONPlayerWin += ONPlayerWin;
        _playerOriginalPosition = _player.transform.position;

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraOriginalPosition = _camera.transform.position;

        numberFailAttempts.text = _totalAttempts.ToString();
    }

    private void ONPlayerDeath(Player obj)
    {
        death.Play();
        _player.SetActive(false);
        status.text = _deathMsg;
        _totalAttempts += 1;
        numberFailAttempts.text = _totalAttempts.ToString();
        Invoke(nameof(ResetGame), 3f);
    }

    private void ONPlayerWin(Player obj)
    {
        throughTheGate.Play();
        _player.SetActive(false);
        status.text = _winMsg;
    }

    private void ResetGame()
    {
        _player.SetActive(true);
        _player.transform.position = _playerOriginalPosition;
        _camera.transform.position = _cameraOriginalPosition;
        status.text = "";
        Time.timeScale = 1;
    }
}
