using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ButtonTriggerable
{
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public override void onButtonActivation()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
    }

    public override void onButtonDeactivation()
    {
        collider.enabled = true;
        spriteRenderer.enabled = true;
    }
}
