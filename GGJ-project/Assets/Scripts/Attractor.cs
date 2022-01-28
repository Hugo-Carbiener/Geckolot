using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private bool isAttracting;
    // ally is the other player
    [SerializeField] private float attractionIntensity;
    [SerializeField] private Transform ally;
    private Rigidbody2D allyRb;
    private Transform player;

    private void Awake()
    {
        player = transform;
        allyRb = ally.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 dir = - (ally.position - player.position) / Vector3.Distance(ally.position, player.position);
            dir *= 1 / Vector2.Distance(ally.position, player.position);
            allyRb.AddForce(dir * attractionIntensity, ForceMode2D.Impulse);
        }
    }
}
