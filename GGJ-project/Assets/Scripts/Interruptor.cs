using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    // The game object which receive interruptor message
    // [SerializeField] GameManager gm;

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
    //            gm.onInterruptorActivation();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if ( col.tag == "Player") {
            onInterruptor--;
            if ( onInterruptor == 0) 
            {
     //           gm.onInterruptorActivation();
            }
        }
    }
}
