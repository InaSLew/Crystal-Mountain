using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int _totalAttempts = 0;
    private GameObject _player;
    private GameObject _camera;
    private Vector2 _playerOriginalPosition;
    private Vector2 _cameraOriginalPosition;
    
    public Text numberFailAttempts;
    public Text status;
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
        status.text = "YOU DIED :'(";
        _totalAttempts += 1;
        numberFailAttempts.text = _totalAttempts.ToString();
        Invoke(nameof(ResetGame), 3f);
    }
    
    private void ONPlayerWin(Player obj)
    {
        status.text = "YOU WIN :D";
    }

    private void ResetGame()
    {
        _player.transform.position = _playerOriginalPosition;
        _camera.transform.position = _cameraOriginalPosition;
        status.text = "";
    }
}
