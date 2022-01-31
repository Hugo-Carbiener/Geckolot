using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public GameObject settingsPanel;
    public TextWriter textWriter;
    public GameManager gm;

    public void Awake()
    {
        //gm = FindObjectOfType<GameManager>();
        //if (gm == null)
        //{
        //    Debug.LogError("Game Manager not found");
        //}
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Debug.Log("Close main mnu");
            closeMainMenu();
        }

    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        textWriter.PauseGame(false);
    }

    public void closeMainMenu()
    {
        this.gameObject.SetActive(false);
        textWriter.ActivateDialogue();
        gm.setPlayersControllable(false);
    }

    public void OpenCredits()
    {
        // open credit scene
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
