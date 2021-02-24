using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{   
    [SerializeField] public Transform feet;
    public LayerMask ground;
    /* Player structure */
    private Rigidbody2D rb;
    private Animator anim;

    /* Player physics */    
    private bool space;
    private float speed; 

    /* Aux */
    private bool facingRight;
    public int MAX_HIGH = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = true;
    }

    bool touchGround(){
        Collider2D coll = Physics2D.OverlapCircle(feet.position, 0.1f, ground);
        return coll!=null;
        
    }
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && touchGround()){
            anim.SetTrigger("isJumping");
            space=true;
        }
        
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
        speed = Input.GetAxis("Horizontal");
    }

    void FixedUpdate(){
        if(space){
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            space = false;
        }

        if(speed > 0 && !facingRight)
            Flip();
        else if(speed < 0 && facingRight)
            Flip();


        rb.velocity = new Vector2 (speed*2, rb.velocity.y);
    }

    void Flip ()
    {
        facingRight = !facingRight;

        // simply rotate player

        transform.Rotate(0f, 180f, 0f);
    }

}
