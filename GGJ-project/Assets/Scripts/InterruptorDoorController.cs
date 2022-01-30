using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is used by the door at the end of the tabs
public class InterruptorDoorController : MonoBehaviour
{
    public int number_buttons;

    private void Start()
    {
        number_buttons=0;
    }

    public void OnInterruptorTriggered()
    {
        number_buttons+=1;
        if(number_buttons==2)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnInterruptorUnTriggered()
    {
        number_buttons-=1;
    }
}
