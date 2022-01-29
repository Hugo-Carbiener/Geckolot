using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{

    [SerializeField] private AudioClip[] jumpAudio;
    [SerializeField] private AudioClip powerAudio;
    [SerializeField] private AudioClip CryAudio;
    [SerializeField] private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJump()
    {
        source.clip = jumpAudio[Random.Range(0, jumpAudio.Length)];
        source.Play();
    }

    public void PlayPower()
    {
        source.clip = powerAudio;
        source.Play();
    }

    public void PlayCry()
    {
        source.clip = CryAudio;
        source.Play();
    }

}
