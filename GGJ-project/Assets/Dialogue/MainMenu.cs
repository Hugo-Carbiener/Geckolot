using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public GameObject settingsPanel;
    public TextWriter textWriter;

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
        textWriter.ActivateDialogue();
    }

    public void OpenCredits()
    {
        // open credit scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
