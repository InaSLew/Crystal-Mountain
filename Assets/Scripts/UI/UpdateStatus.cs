using UnityEngine;
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

    public void OnPlayerDeath() => UpdateTextDisplay(deathMsg);
    public void OnResetGame() => UpdateTextDisplay("");
    private void UpdateTextDisplay(string msg) => textDisplay.text = msg;
}
