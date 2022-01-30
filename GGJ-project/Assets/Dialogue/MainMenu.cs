using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public GameObject settingsPanel;
    public TextWriter textWriter;
    public GameManager gm;

    public void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
        {
            Debug.LogError("Game Manager not found");
        }
    }

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
        textWriter.ActivateDialogue();
        gm.setPlayersControllable(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
