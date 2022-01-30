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

    // Update is called once per frame
    void Update()
    {
        masterMixer.SetFloat("MusicVol", 10*Mathf.Log10(musicSL.value));
        masterMixer.SetFloat("SFXVol", 10*Mathf.Log10(effectSL.value));

    }
}
