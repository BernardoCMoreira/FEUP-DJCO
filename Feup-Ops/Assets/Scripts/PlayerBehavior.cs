using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool space;
    private float speed; 
private bool facingRight;
    public int MAX_HIGH = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
             space=true;
         
        }
        
        speed = Input.GetAxis("Horizontal");

    
    }

    void FixedUpdate(){
        if(space){
            rb.AddForce(Vector2.up * MAX_HIGH, ForceMode2D.Impulse);
            space = false;
        }


        if(speed > 0 && !facingRight)
            Flip();
        else if(speed < 0 && facingRight)
            Flip();


        rb.velocity = new Vector2 (speed * 5, rb.velocity.y);
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
