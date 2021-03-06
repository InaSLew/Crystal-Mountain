using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controls start menu option selecting, confirming and what follows after selecting
/// </summary>
public class StartMenuControl : MonoBehaviour
{
    [Header("Options and credit page")]
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject creditPage;
    
    private readonly int MainScene = 1;
    private AudioSource selectSound;
    
    // Menu select operation related
    private GameObject selectedOption;
    private GameObject[] allOptions;
    private List<GameObject> idleOptions;
    private int accessIndex;

    private void Awake()
    {
        selectSound = GetComponent<AudioSource>();
        allOptions = new[] {start, quit, credit};
        idleOptions = new List<GameObject>();
        accessIndex = 0;
    }

    private void Start()
    {
        selectedOption = allOptions[accessIndex];
        IncreaseAlphaOnSelectedOption();
    }
    
    private void Update()
    {
        SelectAnOption();
        EnterOnSelected();
        CloseCreditPage();
    }

    private void SelectAnOption()
    {
        if (Input.GetKeyDown(KeyCode.S) && accessIndex < allOptions.Length)
        {
            selectSound.Play();
            accessIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.W) && accessIndex > 0)
        {
            selectSound.Play();
            accessIndex--;
        }

        selectedOption = allOptions[accessIndex];
        if (idleOptions.Count != 0) idleOptions.Clear();
        for (var i = 0; i < allOptions.Length; i++)
        {
            if (i != accessIndex) idleOptions.Add(allOptions[i]);
        }
        
        IncreaseAlphaOnSelectedOption();
        foreach (var idleOption in idleOptions)
        {
            DecreaseAlphaOnIdleOption(idleOption);
        }
    }

    private void EnterOnSelected()
    {
        if (!Input.GetKeyDown(KeyCode.Return)) return;
        selectSound.Play();
        if (selectedOption == start) StartGame();
        else if (selectedOption == quit) QuitGame();
        else if (selectedOption == credit) creditPage.SetActive(true);
    }
    
    private void CloseCreditPage()
    {
        if (!credit.activeInHierarchy) return;
        if (Input.GetKeyDown(KeyCode.Q)) creditPage.SetActive(false);
    }
    
    private void StartGame() => SceneManager.LoadScene(MainScene);
    private void QuitGame() => Application.Quit();
    
    private void IncreaseAlphaOnSelectedOption()
    {
        var img = selectedOption.GetComponent<TextMeshProUGUI>().GetComponentInChildren<Image>();
        var tmpColor = img.color;
        tmpColor.a = .4f;
        img.color = tmpColor;
    }
    
    private void DecreaseAlphaOnIdleOption(GameObject idleOption)
    {
        var img = idleOption.GetComponent<TextMeshProUGUI>().GetComponentInChildren<Image>();
        var tmpColor = img.color;
        tmpColor.a = 0;
        img.color = tmpColor;
    }
}
