using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] jumpSound;
    [SerializeField] AudioClip thumbleSound;
    [SerializeField] AudioClip powerSound;
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
        source.clip = jumpSound[Random.Range(0, jumpSound.Length)];
        source.Play();
    }

    public void PlayThumbleSound()
    {
        source.clip = thumbleSound;
        source.Play();
    }

    public void PlayPowerSound()
    {
        source.clip = powerSound;
        source.Play();
    }
}
