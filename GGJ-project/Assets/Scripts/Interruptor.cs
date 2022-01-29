using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{

    [SerializeField] private TableauManager tableau;

    // number of player on the Interruptor
    private int onInterruptor;
    
    // Start is called before the first frame update
    void Start()
    {

        onInterruptor = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.tag == "Player") {
            onInterruptor ++;
            if (onInterruptor == 1)
            {
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
               tableau.interruptorOff();
            }
        }
    }
}
