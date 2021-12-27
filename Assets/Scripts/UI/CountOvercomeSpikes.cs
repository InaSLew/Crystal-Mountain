using UnityEngine;
using UnityEngine.UI;

public class CountOvercomeSpikes : MonoBehaviour
{
    [SerializeField] private IntValue numberOvercomeSpikes;
    [SerializeField] private GameEvent playerSpeedUp;
    [SerializeField] private int speedUpThreshold;
    private Text textDisplay;

    private void Awake()
    {
        numberOvercomeSpikes.Int = 0;
        textDisplay = GetComponent<Text>();
        UpdateTextDisplay();
    }

    public void OnSpikeOvercome()
    {
        numberOvercomeSpikes.Int++;
        UpdateTextDisplay();
        if (HasHitSpeedUpThreshold()) playerSpeedUp.Raise();
    }

    private bool HasHitSpeedUpThreshold() => numberOvercomeSpikes.Int % speedUpThreshold == 0;

    private void UpdateTextDisplay() => textDisplay.text = numberOvercomeSpikes.Int.ToString();
}
