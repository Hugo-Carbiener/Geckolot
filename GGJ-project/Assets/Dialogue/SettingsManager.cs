using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public Slider musicSL;
    public Slider effectSL;
    public GameObject sfxManager;
    public GameObject musicManager;
    public AudioMixer masterMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        masterMixer.SetFloat("MusicVol", 10*Mathf.Log10(musicSL.value));
        masterMixer.SetFloat("SFXVol", 10*Mathf.Log10(effectSL.value));
        //musicManager.GetComponent<AudioSource>().volume = musicSL.value;
        //sfxManager.GetComponent<AudioSource>().volume = effectSL.value;
    }
}
