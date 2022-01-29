using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip[] audioClips;
    private AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        audio.clip = audioClips[Random.Range(0, audioClips.Length)];
        audio.Play();
    }
}
