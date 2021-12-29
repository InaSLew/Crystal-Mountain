using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keeps track of how many spikes player's overcome.
/// </summary>
public class CountOvercomeSpikes : MonoBehaviour
{
    [Header("Number Of spikes player overcomes")]
    [SerializeField] private IntValue numberOvercomeSpikes;
    
    [Header("Game events")]
    [SerializeField] private IntGameEvent playerSpeedUp;
    [SerializeField] private VoidGameEvent hasWinCondition;
    
    [Header("When to speed up and winning condition")]
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
