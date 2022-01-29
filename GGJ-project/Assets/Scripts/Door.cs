using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ButtonTriggerable
{
    private Collider2D collider;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void onButtonActivation()
    {
        collider.enabled = false;
        sr.enabled = false;
    }

    public override void onButtonDeactivation()
    {
        collider.enabled = true;
        sr.enabled = true;
    }
}
