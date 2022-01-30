using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public Slider musicSL;
    public Slider effectSL;
    public GameObject sfxManager;
    public GameObject musicManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        musicManager.GetComponent<AudioSource>().volume = musicSL.value;
        sfxManager.GetComponent<AudioSource>().volume = effectSL.value;
    }
}
