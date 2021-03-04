using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   

    public CameraShake CameraShake;

    [SerializeField] public Transform feet;
    public LayerMask ground;

    /* Player structure */
    private Rigidbody2D rb;
    private Animator anim;

    /* Player physics */    
    private bool space;
    private float speed; 

    /* Player game vars */
    private int score;


    /* Aux */
    public bool facingRight;
    public int MAX_HIGH = 5;
    public int health = 100;

    /* Global vars*/
    public static bool isFrozen;



    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score= 0;
        facingRight = true;
        isFrozen = false;
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

        if (rb.velocity.y >= 0)
        {
            Physics2D.IgnoreLayerCollision(0, 8, true);
        }
        //else the collision will not be ignored
        else
        {
            Physics2D.IgnoreLayerCollision(0, 8, false);
        }

    }

    private void Flip ()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Die(){
        Destroy(gameObject, 1);
        Debug.Log("Player died");
    }

    public void TakeDamage(int damage){
        StartCoroutine(CameraShake.Shake(.15f, .4f));  
        
        health -= damage; 
        Debug.Log("health: " + health);
    }

   void OnCollisionEnter2D(Collision2D col)
    {           
        if(col.gameObject.tag == "Book"){ 
            Destroy(col.gameObject);
            score += 10;
        }
        if(col.gameObject.tag == "Frozen"){ 
            Destroy(col.gameObject);
            isFrozen = true;
            GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                Debug.Log(GetComponent<Clock>());
                c.GetComponent<Clock>().StartFreezeCount(5);
            }
                
        }
    }




}
