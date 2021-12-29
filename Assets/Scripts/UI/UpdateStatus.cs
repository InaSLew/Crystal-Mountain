using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Listens for game events and displays in-game status to player accordingly.
/// </summary>
public class UpdateStatus : MonoBehaviour
{
    private readonly string deathMsg = "YOU DIED :'( RESTART IN 3 seconds...";
    private readonly string winMsg = "YOU WIN :D";
    private Text textDisplay;

    private void Awake()
    {
        textDisplay = GetComponent<Text>();
    }

    public void OnPlayerDeath()
    {
        AdjustBackgroundAlpha(.2f);
        UpdateTextDisplay(deathMsg);
    }

    public void OnResetGame() => HideStatus();

    public void OnPlayerWin()
    {
        AdjustBackgroundAlpha(.2f);
        UpdateTextDisplay(winMsg);
    }

    public void OnPlayerSpeedUp(int spikesLeft)
    {
        AdjustBackgroundAlpha(.2f);
        UpdateTextDisplay($"{spikesLeft} spikes to go! Go a lil' faster!");
        Invoke(nameof(HideStatus), 1f);
    }

    private void AdjustBackgroundAlpha(float newAlpha)
    {
        var img = GetComponentInChildren<Image>();
        var tmpColor = img.color;
        tmpColor.a = newAlpha;
        img.color = tmpColor;
    }
    
    private void UpdateTextDisplay(string msg) => textDisplay.text = msg;

    private void HideStatus()
    {
        AdjustBackgroundAlpha(0);
        UpdateTextDisplay("");
    }
}
