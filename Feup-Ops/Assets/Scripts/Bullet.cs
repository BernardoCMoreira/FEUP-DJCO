using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public Rigidbody2D rb;
    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5); //Destruir ao fim de 5sec, mesmo q n toque em nada
    }

    void OnTriggerEnter2D(Collider2D hitInfo){

        if(hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.name) == "Player") ){ //se for rigid body
            return;
        }

        Enemy enemy  = hitInfo.GetComponent<Enemy>();
        if(enemy!= null){
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
