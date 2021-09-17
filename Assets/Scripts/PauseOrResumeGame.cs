using System;
using UnityEngine;

public class PauseOrResumeGame : MonoBehaviour
{
    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0;
        _player.GetComponent<Rigidbody2D>().Sleep();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _player.GetComponent<Rigidbody2D>().WakeUp();
    }
}
