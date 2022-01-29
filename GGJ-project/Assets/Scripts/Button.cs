using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // The game object which receive Button message
    [SerializeField] ButtonTriggerable triggerable;

    // number of player on the Button
    private int onButton;
    
    // Start is called before the first frame update
    void Start()
    {
        onButton = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.tag == "Player") {
            onButton ++;
            if (onButton == 1)
            {
                triggerable.onButtonActivation();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if ( col.tag == "Player") {
            onButton--;
            if ( onButton == 0) 
            {
                triggerable.onButtonDeactivation();
            }
        }
    }
}
