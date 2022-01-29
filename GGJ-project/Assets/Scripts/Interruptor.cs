using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{

    [SerializeField] private TableauManager tableau;
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;

    // number of player on the Interruptor
    private int onInterruptor;
    
    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
    }
}
