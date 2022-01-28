using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // TODO send a message to the game manager
        Debug.Log("Player on button");
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // TODO send a message to the game manager
        Debug.Log("Player not on button");
    }
}
