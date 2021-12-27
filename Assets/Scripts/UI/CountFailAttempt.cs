using UnityEngine;
using UnityEngine.UI;

public class CountFailAttempt : MonoBehaviour
{
    private int totalAttempts = 0;
    private Text failAttemptDisplay;

    private void Awake()
    {
        failAttemptDisplay = GetComponent<Text>();
        failAttemptDisplay.text = totalAttempts.ToString();
    }

    public void OnPlayerDeath()
    {
        totalAttempts++;
        failAttemptDisplay.text = totalAttempts.ToString();
    }
}
