using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : PlatformerController
{

    public GameObject lightningBolt;
    public int magicAbility = 1;
    bool doEvent = false;
    // Start is called before the first frame update
    void Start(){
        //Get Current magic
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    void Action(){
        
    }
    
    void OnTriggerStay2D(Collision2D other){
        //For the Attack
        if(other.transform.tag.ToLower().CompareTo("event") == 0){
            doEvent = true;
        }

        if(other.transform.tag.ToLower().CompareTo("enemy") == 0){
            //Do Damage to enemy
        }
    }

    void OnTriggerExit2D(Collision2D other){
        if(other.transform.tag.ToLower().CompareTo("event") == 0){
            doEvent = false;
        }
    }

}
