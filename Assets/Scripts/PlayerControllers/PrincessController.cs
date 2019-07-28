using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessController : PlatformerController
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void Action(){
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.transform.tag.ToLower().CompareTo("enemy") == 0){
            if(rb.velocity.y < 0 && !isGrounded){ //Only if I am falling can I kill an enemy
                rb.velocity = new Vector2(rb.velocity.x, 10);
            }
        }
    }
}
