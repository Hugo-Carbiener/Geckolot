using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ButtonTriggerable
{
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void onButtonActivation()
    {
        gameObject.SetActive(false);
        collider.enabled = false;
        spriteRenderer.enabled = false;
    }

    public override void onButtonDeactivation()
    {
        gameObject.SetActive(true);
        collider.enabled = true;
        spriteRenderer.enabled = true;
    }
}
