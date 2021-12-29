using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Increments player's total failed attempts/runs everytime VoidGameEvent PlayerIsDead fires 
/// </summary>
public class CountFailAttempt : MonoBehaviour
{
    private int totalAttempts = 0;
    private Text textDisplay;

    private void Awake()
    {
        textDisplay = GetComponent<Text>();
        UpdateTextDisplay();
    }

    public void OnPlayerDeath()
    {
        totalAttempts++;
        UpdateTextDisplay();
    }

    private void UpdateTextDisplay() => textDisplay.text = totalAttempts.ToString();
}
