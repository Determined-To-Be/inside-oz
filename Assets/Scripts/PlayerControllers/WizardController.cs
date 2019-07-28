using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : PlatformerController
{

    public GameObject lightningBolt;
    public int magicAbility = 1;
    bool doEvent = false;

    public GameObject attackTrigger;
    // Start is called before the first frame update
    void Start(){
        //Get Current magic
        base.Start();
        PlayerPrefs.GetFloat("magic");
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    void Action(){
        
    }

    void ShootLightning(){
        GameObject go = Instantiate(lightningBolt, this.transform.position, Quaternion.identity)
    }
    
    void OnTriggerStay2D(Collider2D other){
        //For the Attack
        if(other.transform.tag == "Event"){
            doEvent = true;
        }

        if(other.transform.tag == "Enemy"){
            //Do Stun Enemy
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "Event"){
            doEvent = false;
        }
    }

}
