using UnityEngine;

public class PauseOrResumeGame : MonoBehaviour
{
    public void PauseGame() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;
}
