using UnityEngine;
using UnityEngine.UI;

public class CountOvercomeSpikes : MonoBehaviour
{
    [SerializeField] private Text textDisplay;
    [SerializeField] private IntValue numberOvercomeSpikes;

    private void Awake()
    {
        numberOvercomeSpikes.Int = 0;
        UpdateTextDisplay();
    }

    public void OnSpikeOvercome()
    {
        numberOvercomeSpikes.Int++;
        UpdateTextDisplay();
    }

    private void UpdateTextDisplay() => textDisplay.text = numberOvercomeSpikes.Int.ToString();
}
