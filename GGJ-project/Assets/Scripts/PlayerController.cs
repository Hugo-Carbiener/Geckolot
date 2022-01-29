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
    [SerializeField] private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded=true;
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------
        
        //----------------------------------
        float horizontal_input=0f;
        if(isAttractor)
        {
            if(Input.GetKey("d"))
            {
                horizontal_input+=1;
            }
            if (Input.GetKey("q"))
            {
                horizontal_input-=1;
            }
            if(Input.GetKeyDown("z") && isGrounded )
            {
                Jump();
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                horizontal_input+=1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal_input-=1;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded )
            {
                Jump();
            }
        }
        rb.velocity=new Vector2(horizontal_input*speed,rb.velocity.y);
    }

    //the function used to jump :
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded=false;
    }

    //the function that indicates if the player is grounded :
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            isGrounded=true;
        }
    }

    //the function that handles the reset of the player
    public void ResetPlayer(Vector2 position)
    {
        //the coroutine FaderReset() MUST be called by a singular instance (GameManager for ex)
        // StartCoroutine(FaderReset()); //TO DELETE
        //----------------------------------------
        gameObject.transform.position=position;
    }

    //this function will launch the fading process
    private IEnumerator FaderReset()
    {
        GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>().LaunchFadeIn();
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>().LaunchFadeOut();
    }
}
