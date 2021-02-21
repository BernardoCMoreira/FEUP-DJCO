using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private bool space;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
             space=true;
        }
    }

    void FixedUpdate(){
        if(space){
            rigidBody.AddForce(Vector2.up*2, ForceMode2D.Impulse);
            space = false;
        }

    }

}
