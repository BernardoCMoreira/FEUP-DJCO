using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{    
    Rigidbody2D rb;
    Animator anim;
    bool space;
    private float speed; 

    [SerializeField] CameraShake CameraShake;
    [SerializeField] LayerMask ground;
    [SerializeField] bool facingRight;
    [SerializeField] int health = 100;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float playerSpeed = 3;
    [SerializeField] HealthBar healthBar;
    [SerializeField] BookBar bookBar;

    /* Global vars*/
    public static bool isFrozen;
    public static int level;
    public static int score;
    public static int scroll;

    public Transform feet;

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

        fixHealthBar();
    }

    private void fixHealthBar(){
        Vector3 theScale = gameObject.transform.GetChild(2).GetChild(0).localScale;
        theScale.x *= -1;
        gameObject.transform.GetChild(2).GetChild(0).gameObject.transform.localScale = theScale;
    }

    public void Die(){
        GameController gameController = GetComponent<GameController>();

        if(gameController){
            gameController.endGame();
        }
    }

    public void DestroyPlayer(){
        Destroy(gameObject, 0.5f);
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
            collect(col);
            score += 1;
            bookBar.SetScore(score);
        }
        if(col.gameObject.tag == "Scroll"){ 
            collect(col);
            scroll += 1;
            GameObject.Find("ImageScroll_Inactive").SetActive(false);
        }
        if(col.gameObject.tag == "Frozen"){
            collect(col);
            isFrozen = true;
            GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                c.GetComponent<Clock>().StartFreezeCount(5);
            }
        }
        if(col.gameObject.tag == "Heart"){
            collect(col);
            health += 20;
            healthBar.SetHealth(health);
        }
    }

    private void collect(Collision2D col){
        SoundManager.playSound("collectable", 0.6f);
        Destroy(col.gameObject);
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
        gameObject.transform.position = new Vector2(-17f,-35f);
    }

    public void exitSecretLevel(){
        gameObject.transform.position = new Vector2(22f,-7.7f);
    }

    public int getScore(){
        return score;
    }

    public bool hasScroll(){
        return scroll==1;
    }
}
