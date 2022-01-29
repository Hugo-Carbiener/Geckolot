using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ButtonTriggerable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    abstract public void onButtonActivation();

    abstract public void onButtonDeactivation();

}
