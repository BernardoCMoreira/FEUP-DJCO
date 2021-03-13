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

    /* Aux */
    public GameOverScreen gameOverScreen;
    public bool facingRight;
    public int MAX_HIGH = 5;
    public int health = 100;
    public float jumpForce = 5;
    public float playerSpeed = 3;

    /* Global vars*/
    public static bool isFrozen;
    public static int level;
    public static int score;
    public static int scroll;

    /*Life bar*/
    public HealthBar healthBar;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
        scroll = 0;
        facingRight = true;
        isFrozen = false;
        healthBar.SetMaxHealth(health);
        level = 1;
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

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey ("w")) && touchGround()){            
            anim.SetTrigger("isJumping");
            space=true;
        }
        
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey ("d") || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey ("a")) {
            anim.SetBool("isWalkingRight", true);
        } else {
            anim.SetBool("isWalkingRight", false);
        }

        speed = Input.GetAxis("Horizontal");
    }

    void FixedUpdate(){
        updateLevel();
        
        if(space){
            SoundManager.playSound("playerJump", 0.4f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            space = false;
        }

        float h = Input.GetAxis("Horizontal");
        if(h > 0 && !facingRight)
            Flip();
        else if(h < 0 && facingRight)
            Flip();

        rb.velocity = new Vector2 (speed*playerSpeed, rb.velocity.y);

        if (rb.velocity.y >= 0)
        {
            Physics2D.IgnoreLayerCollision(9, 8, true);
            Physics2D.IgnoreLayerCollision(9, 10, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 8, false);
        }
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Die(){
        string time = "00:00";
        GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                Debug.Log(GetComponent<Clock>());
                time = c.GetComponent<Clock>().getCurrentTime();
            }
        gameOverScreen.Setup(score, time);
        Destroy(gameObject);
        Debug.Log("Player died");
    }

    public void TakeDamage(int damage){
        //SoundManager.playSound("playerHit", 0.5f);
        StartCoroutine(CameraShake.Shake(.15f));  
        health -= damage; 
        healthBar.SetHealth(health);
    }

   void OnCollisionEnter2D(Collision2D col)
    {           
        if(col.gameObject.tag == "Book"){ 
            SoundManager.playSound("collectable", 0.6f);
            Destroy(col.gameObject);
            score += 1;
        }

        if(col.gameObject.tag == "Scroll"){ 
            SoundManager.playSound("collectable", 0.6f);
            Destroy(col.gameObject);
            scroll += 1;
        }
        
        if(col.gameObject.tag == "Frozen"){ 
            SoundManager.playSound("collectable", 0.6f);
            Destroy(col.gameObject);
            isFrozen = true;
            GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                Debug.Log(GetComponent<Clock>());
                c.GetComponent<Clock>().StartFreezeCount(5);
            }
        }
        if(col.gameObject.tag == "Heart"){ 
            SoundManager.playSound("collectable", 0.6f);
            Destroy(col.gameObject);
            health += 20;
            healthBar.SetHealth(health);
        }
    }


    private void updateLevel(){
        if(gameObject.transform.position.x > -15f && gameObject.transform.position.x < 16f &&
            gameObject.transform.position.y > - 10f && gameObject.transform.position.y < 10f ) {
            level = 1;
        } else if (gameObject.transform.position.x >= 16f && gameObject.transform.position.x < 32f &&
            gameObject.transform.position.y > - 10f && gameObject.transform.position.y < 10f ) {
                level = 2;
            }
    }


    public void shoot(float xCoord, float yCoord){
        if(facingRight && xCoord < 0){
            anim.SetTrigger("FacingRight_LeftShot");
        }
        else if(!facingRight && xCoord > 0) {
            anim.SetTrigger("FacingLeft_RightShot");
            facingRight=false;
        }
    }

    public void enterSecretLevel(){
        Debug.Log("ENTER Secret LEVEL! ................");
        gameObject.transform.position = new Vector2(-17f,-22.5f);
    }

    public void exitSecretLevel(){
        Debug.Log("Exit Secret LEVEL!");
        gameObject.transform.position = new Vector2(-17f,-6f);
    }
}
