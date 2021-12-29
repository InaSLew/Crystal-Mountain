using UnityEngine;
using UnityEngine.UI;

public class CountOvercomeSpikes : MonoBehaviour
{
    [SerializeField] private IntValue numberOvercomeSpikes;
    [SerializeField] private IntGameEvent playerSpeedUp;
    [SerializeField] private VoidGameEvent hasWinCondition;
    [SerializeField] private int speedUpThreshold;
    [SerializeField] private int spikeOvercomeToWin;
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
        if (HasHitWinCondition()) hasWinCondition.Raise(new GenericVoid()); 
        else if (HasHitSpeedUpThreshold()) playerSpeedUp.Raise(spikeOvercomeToWin - numberOvercomeSpikes.Int);
    }

    private bool HasHitWinCondition() => numberOvercomeSpikes.Int == spikeOvercomeToWin;

    private bool HasHitSpeedUpThreshold() => numberOvercomeSpikes.Int % speedUpThreshold == 0;

    private void UpdateTextDisplay() => textDisplay.text = numberOvercomeSpikes.Int.ToString();
}
