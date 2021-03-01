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
    public bool facingRight;
    public int MAX_HIGH = 5;
    public int health = 100;


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
        if(health <= 0 ) {
            //TODO: arranjar anim;
            Die();
        }

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

    public void Flip ()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Die(){
        //Destroy(gameObject); //Perguntar ao prof se o melhor é terminar a cena e matar todos de uma vez ou 1 a 1...
        Debug.Log("Player died");
    }

    public void TakeDamage(int damage){
        health -= damage; 
        Debug.Log(health);
    }

}
