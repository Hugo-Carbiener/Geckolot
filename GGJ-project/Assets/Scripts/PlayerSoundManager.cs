using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] jumpFiles;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource thumbleSound;
    [SerializeField] AudioSource powerSound;
    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        jumpSound.clip = jumpFiles[Random.Range(0, jumpFiles.Length)];
        jumpSound.Play();
    }

    public void PlayThumbleSound()
    {
        thumbleSound.PlayDelayed(0.1f);
    }

    public void PlayPowerSound()
    {
        powerSound.Play();
    }
}
