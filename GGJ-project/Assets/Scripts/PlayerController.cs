using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used by the player
//it will direct the player with the inputs
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isAttractor;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal_input=0f;
        if(isAttractor){
            if(Input.GetKey("d"))
            {
                horizontal_input+=1;
            }
            if (Input.GetKey("q"))
            {
                horizontal_input-=1;
            }
            if(Input.GetKeyDown("z") && UpdateGrounded() )
            {
                Jump();
            }
            rb.velocity=new Vector2(horizontal_input*speed,rb.velocity.y);
        }
    }

    //the function used to jump :
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    //the function that indicates if the player is grounded :
    private bool UpdateGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down);
        return isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 200f);
    }
}
