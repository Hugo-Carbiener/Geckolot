using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private bool isAttracting;
    // ally is the other player
    [SerializeField] private float range;
    [SerializeField] private float attractionIntensity;
    [SerializeField] private Transform ally;
    [SerializeField] private float maxForce;
    [SerializeField] private bool isPowerUsable = true;
    [SerializeField] private GameObject attractorPower;
    private PlayerSoundManager playerSound;
    private Rigidbody2D allyRb;
    private Transform player;
    private Animator allyAnim;
    private PlayerController allyPlayer;

    //IOT
    public bool powerActive;
    public bool IoT;

    private void Awake()
    {
        player = transform;
        playerSound = GetComponent<PlayerSoundManager>();
        allyRb = ally.GetComponent<Rigidbody2D>();
        allyAnim = ally.GetComponent<Animator>();
        allyPlayer=ally.GetComponent<PlayerController>();
        powerActive = false;
    }

    public void setPowerUsable(bool val)
    {
        this.isPowerUsable = val;
    }
    
    private void FixedUpdate()
    {
        if (!IoT)
        {
            if (Input.GetKey(KeyCode.Space) && isPowerUsable)
            {
                float distance = Vector2.Distance(ally.position, player.position);
                if (distance < range && distance > 0.6)
                {
                    attractorPower.SetActive(true);
                    Vector2 dir = -(ally.position - player.position) / distance;
                    dir *= 1 / distance;
                    allyRb.AddForce(dir * attractionIntensity, ForceMode2D.Impulse);
                    if (allyPlayer.is_tumbled == false)
                    {
                        playerSound.PlayPowerSound();
                        allyPlayer.audioManager.PlayThumbleSound();
                    }
                    allyPlayer.is_tumbled = true;
                }
                else
                {
                    allyPlayer.is_tumbled = false;
                    attractorPower.SetActive(false);
                }
            }
        }
        else
        {
            if (powerActive && isPowerUsable)
            {
                float distance = Vector2.Distance(ally.position, player.position);
                if (distance < range && distance > 0.6)
                {
                    attractorPower.SetActive(true);
                    Vector2 dir = -(ally.position - player.position) / distance;
                    dir *= 1 / distance;
                    allyRb.AddForce(dir * attractionIntensity, ForceMode2D.Impulse);
                    if (allyPlayer.is_tumbled == false)
                    {
                        playerSound.PlayPowerSound();
                        allyPlayer.audioManager.PlayThumbleSound();
                    }
                    allyPlayer.is_tumbled = true;
                }
                else
                {
                    allyPlayer.is_tumbled = false;
                    attractorPower.SetActive(false);
                }
            }
        }
    }
}
