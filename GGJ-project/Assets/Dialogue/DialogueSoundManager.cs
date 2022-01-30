using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class DialogueSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource blabla;
    [SerializeField] private AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setVoice(int charId)
    {
        // Gecko
        if(charId == 0)
        {
            masterMixer.SetFloat("VoicePitch", 1.5f);
        }
        else // Axolotl
        {
            masterMixer.SetFloat("VoicePitch", 1.0f);
        }
    }
    public void PlaySound()
    {
        blabla.Play();
    }
}
