using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsor : MonoBehaviour
{
    private bool isRepulsing;
    // ally is the other player
    [SerializeField] private float range;
    [SerializeField] private float repulsionIntensity;
    [SerializeField] private Transform ally;
    [SerializeField] private bool isPowerUsable = true;
    [SerializeField] private GameObject repulsorPower;

    private Rigidbody2D allyRb;
    private Transform player;
    private Animator allyAnim;
    private PlayerController allyPlayer;

    private void Awake()
    {
        player = transform;
        allyRb = ally.GetComponent<Rigidbody2D>();
        allyAnim = ally.GetComponent<Animator>();
        allyPlayer=ally.GetComponent<PlayerController>();
    }
    
    public void setPowerUsable(bool val)
    {
        this.isPowerUsable = val;
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightShift) && isPowerUsable)
        {
            float distance = Vector2.Distance(ally.position, player.position);
            if (distance < range && distance > 0.6)
            {
                repulsorPower.SetActive(true);
                Vector2 dir = (ally.position - player.position) / distance;
                dir *= 1 / distance;
                allyRb.AddForce(dir * repulsionIntensity, ForceMode2D.Impulse);
                allyPlayer.is_tumbled=true;
            }
        } else {
            allyPlayer.is_tumbled=false;
            repulsorPower.SetActive(false);
        }
    }
}
