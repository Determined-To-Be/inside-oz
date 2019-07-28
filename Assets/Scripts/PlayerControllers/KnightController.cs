using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlatformerController
{

    public int courage = 1;
    bool doEvent = false;
    Animator animator;

    // Start is called before the first frame update
    void Start(){
        base.Start();
        PlayerPrefs.GetFloat("courage"); //Get current courage values
    }

    // Update is called once per frame
    void Update(){
        
    }

    void Action(){

    }

    void SwordSwing(){

    }

    void OnTriggerStay2D(Collider2D other){
        //For the Attack
        if(other.transform.tag == "Event"){
            doEvent = true;
        }

        if(other.transform.tag == "Enemy"){
            //Do Kill Enemy
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag.ToLower().CompareTo("event") == 0){
            doEvent = false;
        }
    }
}
