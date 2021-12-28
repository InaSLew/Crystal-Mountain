using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject quit;

    private GameObject selectedOption;
    private GameObject idleOption;
    private readonly int MainScene = 1;
    private AudioSource select;

    private void Awake()
    {
        select = GetComponent<AudioSource>();
    }

    private void Start()
    {
        selectedOption = start;
        idleOption = quit;
        IncreaseAlphaOnSelectedOption();
    }
    
    private void Update()
    {
        ToggleBetweenStartAndQuit();
        EnterOnSelected();
    }

    private void EnterOnSelected()
    {
        if (Input.GetKeyDown(KeyCode.Return) && selectedOption == start)
        {
            select.Play();
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && selectedOption == quit)
        {
            select.Play();
            QuitGame();
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(MainScene);
    }

    private void QuitGame() => Application.Quit();

    private void ToggleBetweenStartAndQuit()
    {
        if (Input.GetKeyDown(KeyCode.S) && selectedOption == start)
        {
            select.Play();
            selectedOption = quit;
            idleOption = start;
        }
        else if (Input.GetKeyDown(KeyCode.W) && selectedOption == quit)
        {
            select.Play();
            selectedOption = start;
            idleOption = quit;
        }
        IncreaseAlphaOnSelectedOption();
        DecreaseAlphaOnIdleOption();
    }

    private void IncreaseAlphaOnSelectedOption()
    {
        var img = selectedOption.GetComponent<TextMeshProUGUI>().GetComponentInChildren<Image>();
        var tmpColor = img.color;
        tmpColor.a = .4f;
        img.color = tmpColor;
    }
    
    private void DecreaseAlphaOnIdleOption()
    {
        var img = idleOption.GetComponent<TextMeshProUGUI>().GetComponentInChildren<Image>();
        var tmpColor = img.color;
        tmpColor.a = 0;
        img.color = tmpColor;
    }
}
