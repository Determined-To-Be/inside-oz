using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessController : PlatformerController
{

    public float bounceVelocity = 15f;
    // Start is called before the first frame update
    void Start(){
        base.Start();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void Action(){

    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.transform.tag == "Enemy"){
            Debug.Log(rb.velocity.y);
            if(rb.velocity.y <= 2){ //Only if I am falling can I kill an enemy
                rb.velocity = new Vector2(rb.velocity.x, bounceVelocity);
                return;
            }
        }
    }
}
