using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{

    [SerializeField] private TableauManager tableau;
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    [SerializeField] private GameObject door;
    private AudioSource sound;

    // number of player on the Interruptor
    private int onInterruptor;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        onInterruptor = 0;  
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.tag == "Player") {
            onInterruptor ++;
            if (onInterruptor == 1)
            {
                on.SetActive(true);
                off.SetActive(false);
                tableau.interruptorOn();
                door.GetComponent<InterruptorDoorController>().OnInterruptorTriggered();
                sound.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if ( col.tag == "Player") {
            onInterruptor--;
            if ( onInterruptor == 0) 
            {
                off.SetActive(true);
                on.SetActive(false);
                tableau.interruptorOff();
                door.GetComponent<InterruptorDoorController>().OnInterruptorUnTriggered();
            }
        }
    }
}
