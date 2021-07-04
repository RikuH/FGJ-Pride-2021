using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartBtn;
    public Button CreditsBtn;
    public Button ManualBtn;
    public Button BackCreditsBtn;
    public Button BackManualBtn;
    public Button QuitBtn;


    public GameObject CreditsPanel;
    public GameObject ManualPanel;
    public GameObject MainPanel;


    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(StartGame);
        CreditsBtn.onClick.AddListener(CreditsPanelActive);
        ManualBtn.onClick.AddListener(ManualPanelActive);
        BackCreditsBtn.onClick.AddListener(BackCreditsToMain);
        BackManualBtn.onClick.AddListener(BackManualToMain);
        QuitBtn.onClick.AddListener(QuitGame);
        Screen.SetResolution(1920, 1080, true);
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
        //Debug.Log("Avaa pelin");
    }

    void QuitGame()
    {
        //Debug.Log("Lopettaa pelin");
        Application.Quit();
    }

    void CreditsPanelActive()
    {
        CreditsPanel.SetActive(true);
        MainPanel.SetActive(false);

    }

    void ManualPanelActive()
    {
        ManualPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    void BackCreditsToMain()
    {
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    void BackManualToMain()
    {
        Debug.Log("is clicked");
        ManualPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

}
