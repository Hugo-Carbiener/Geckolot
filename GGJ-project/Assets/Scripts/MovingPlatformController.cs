using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used by the moving platforms
public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] private float speed=3;
    [SerializeField] private bool is_horizontal;
    [SerializeField] private float distanceTimer; //the timer indicates to where the platform moves (length)
    private string bigScale;
    Rigidbody2D rb;
    private float timer=0f;
    private float shortTime=3f;
    private float pause=1f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(is_horizontal)
        {
            bigScale="x";
        }
        else
        {
            bigScale="y";
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer<=distanceTimer)
        {
            movement(speed);
        }
        if((timer>3)&&(timer<=4))
        {
            rb.velocity=new Vector2(0,0);
        }
        if((timer>4) && (timer<=4+distanceTimer))
        {
            movement(-speed);
        }
        if((timer>8) && (timer<=9))
        {
            rb.velocity=new Vector2(0,0);
        }
        if((timer>9))
        {
            timer=0;
        }
    }

    private void movement(float speed)
    {
        if(bigScale=="x")
        {
            rb.velocity=new Vector2(speed,0);
        }
        else
        {
            rb.velocity=new Vector2(0,speed);
        }
    }
}
