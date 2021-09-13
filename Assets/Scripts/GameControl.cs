using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private int _totalAttempts = 0;
    private GameObject _player;
    private GameObject _camera;
    private Vector2 _playerOriginalPosition;
    private Vector2 _cameraOriginalPosition;
    private void Start()
    {
        Debug.Log($"YOU HAVE TRIED {_totalAttempts}(s)");
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.GetComponent<Player>().ONPlayerDeath += ONPlayerDeath;
        _player.GetComponent<Player>().ONPlayerWin += ONPlayerWin;
        _playerOriginalPosition = _player.transform.position;

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraOriginalPosition = _camera.transform.position;
    }
    
    private void ONPlayerDeath(Player obj)
    {
        Debug.Log("YOU DIED :'(");
        _totalAttempts += 1;
        StopPlayer();
        Invoke(nameof(ResetGame), 3f);
    }
    
    private void ONPlayerWin(Player obj)
    {
        Debug.Log("YOU WIN!!");
        StopPlayer();
    }

    private void StopPlayer()
    {
        _player.GetComponent<PlayerMovement>()._speed = 0;
    }

    private void ResetGame()
    {
        Debug.Log($"YOU HAVE TRIED {_totalAttempts} time(s)");
        _player.transform.position = _playerOriginalPosition;
        _camera.transform.position = _cameraOriginalPosition;
    }
}
