using TMPro;
using UnityEngine;

public class ShowTotalSpikes : MonoBehaviour
{
    [SerializeField] private IntValue numberTotalSpikes;
    private TextMeshProUGUI textDisplay;

    private void Awake()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        textDisplay.text = numberTotalSpikes.Int.ToString();
    }
}
