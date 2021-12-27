using UnityEngine;
using UnityEngine.UI;

public class UpdateStatus : MonoBehaviour
{
    private readonly string deathMsg = "YOU DIED :'( RESTART IN 3 seconds...";
    private readonly string winMsg = "YOU WIN :D";
    private Text statusDisplay;

    private void Awake()
    {
        statusDisplay = GetComponent<Text>();
    }

    public void OnPlayerDeath() => statusDisplay.text = deathMsg;
}
