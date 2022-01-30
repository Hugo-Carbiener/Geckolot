using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // The game object which receive Button message
    [SerializeField] ButtonTriggerable triggerable;
    [SerializeField] GameObject on;
    [SerializeField] GameObject off;
    private AudioSource sound;

    // number of player on the Button
    private int onButton;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
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
                on.SetActive(true);
                off.SetActive(false);
                sound.Play();
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
                off.SetActive(true);
                on.SetActive(false);
                triggerable.onButtonDeactivation();
            }
        }
    }
}
