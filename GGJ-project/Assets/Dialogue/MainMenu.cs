using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public GameObject settingsPanel;
    public TextWriter dialogue;
    public void StartGame()
    {

    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void closeMainMenu()
    {
        this.gameObject.SetActive(false);
        dialogue.ActivateDialogue();

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
