using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Increments player's total failed attempts/runs everytime VoidGameEvent PlayerIsDead fires 
/// </summary>
public class CountFailAttempt : MonoBehaviour
{
    [SerializeField] private IntValue totalAttempts;
    
    private Text textDisplay;

    private void Awake()
    {
        totalAttempts.Int = 0;
        textDisplay = GetComponent<Text>();
        UpdateTextDisplay();
    }

    public void OnPlayerDeath()
    {
        totalAttempts.Int++;
        UpdateTextDisplay();
    }

    private void UpdateTextDisplay() => textDisplay.text = totalAttempts.Int.ToString();
}
