using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsor : MonoBehaviour
{
    private bool isRepulsing;
    // ally is the other player
    [SerializeField] private float repulsionIntensity;
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
        if (Input.GetKey(KeyCode.RightControl))
        {
            Vector2 dir = (ally.position - player.position) / Vector3.Distance(ally.position, player.position);
            dir *= 1 / Vector2.Distance(ally.position, player.position);
            allyRb.AddForce(dir * repulsionIntensity, ForceMode2D.Impulse);
        }
    }
}
