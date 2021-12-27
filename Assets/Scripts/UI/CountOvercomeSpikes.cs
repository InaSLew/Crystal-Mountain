using UnityEngine;
using UnityEngine.UI;

public class CountOvercomeSpikes : MonoBehaviour
{
    [SerializeField] private IntValue numberOvercomeSpikes;
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
    }

    private void UpdateTextDisplay() => textDisplay.text = numberOvercomeSpikes.Int.ToString();
}
