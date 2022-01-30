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
    public PlayerSoundManager audioManager;
    private Animator anim;
    private SpriteRenderer renderer;
    public bool is_tumbled;

    // Start is called before the first frame update
    void Start()
    {
        is_tumbled=false;
        isGrounded=true;
        anim=this.GetComponent<Animator>();
        renderer=this.GetComponent<SpriteRenderer>();
        audioManager = GetComponent<PlayerSoundManager>();
    }

    // FixedUpdate is called once per frame
    void Update()
    {
        anim.SetBool("is_running",false);
        anim.SetBool("is_idle",true);
        anim.SetBool("is_tumbling",false);
        anim.SetBool("is_falling",false);
        anim.SetBool("is_jumping",false);
        float horizontal_input=0f;       
        if(isAttractor)
        {
            if(Input.GetKey("d"))
            {
                horizontal_input+=1;
                renderer.flipX=false;
                anim.SetBool("is_running",true);
            }
            if (Input.GetKey("q"))
            {
                horizontal_input-=1;
                renderer.flipX=true;
                anim.SetBool("is_running",true);
            }
            if(Input.GetKeyDown("z") && isGrounded )
            {
                Jump();
                anim.SetBool("is_jumping",true);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                horizontal_input+=1;
                anim.SetBool("is_running",true);
                renderer.flipX=false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal_input-=1;
                renderer.flipX=true;
                anim.SetBool("is_running",true);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded )
            {
                Jump();
                anim.SetBool("is_jumping",true);
            }
        }
        rb.velocity=new Vector2(horizontal_input*speed,rb.velocity.y);
        Animation();
    }

    //the function used to jump :
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded=false;
        audioManager.PlayJumpSound();
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
        gameObject.transform.position=position;
    }

    //this function is the one that handles the animation
    private void Animation()
    {
         if(is_tumbled){
            anim.SetBool("is_tumbling",true);
            anim.SetBool("is_running",false);
            anim.SetBool("is_idle",false);
            anim.SetBool("is_jumping",false);
            anim.SetBool("is_falling",false);
            anim.SetBool("isGrounded",false);
            return;
        }
        anim.SetBool("isGrounded",isGrounded);
        if(rb.velocity.y<0)
        {
            anim.SetBool("is_falling",true);
            return;
        }
        if(isGrounded)
        {
            if(rb.velocity.x==0)
            {
                anim.SetBool("is_idle",true);
                return;
            }
        }
        if(rb.velocity.y>0)
        {
            anim.SetBool("is_jumping",true);
            return;
        }
    }
}
