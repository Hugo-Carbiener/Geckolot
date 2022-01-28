using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{

    // the game manager who receive message
    //  [SerializeField] GameManager gm;

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
        
        if ( col.tag == "player") {
            onInterruptor ++;
            // TODO send a message to the game manager
            Debug.Log("Player(s) on interruptor");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if ( col.tag == "player") {
            onInterruptor--;
            if ( onInterruptor == 0) {
                // TODO send a message to the game manager
                Debug.Log("No player on interruptor");
            }
        }

    }
}
