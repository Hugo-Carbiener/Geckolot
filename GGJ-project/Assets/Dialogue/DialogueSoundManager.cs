using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class DialogueSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource blabla;
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
        
    }
    public void PlaySound()
    {
        blabla.Play();
    }
}
