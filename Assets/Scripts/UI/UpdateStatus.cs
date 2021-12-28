using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void OnResetGame()
    {
        AdjustBackgroundAlpha(0);
        UpdateTextDisplay("");
    }

    private void AdjustBackgroundAlpha(float newAlpha)
    {
        var img = GetComponentInChildren<Image>();
        var tmpColor = img.color;
        tmpColor.a = newAlpha;
        img.color = tmpColor;
    }
    
    private void UpdateTextDisplay(string msg) => textDisplay.text = msg;
}
