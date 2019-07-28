using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : PlatformerController
{

    public GameObject lightningBolt;
    public int magicAbility = 1;
    bool doEvent = false;
    public float coolDownTime = 1f;
    public bool canShoot = true;

    public GameObject attackTrigger;
    // Start is called before the first frame update
    void Start(){
        //Get Current magic
        base.Start();
        PlayerPrefs.GetFloat("maxMP");
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetButtonDown("Action")){
            if(doEvent){
                return;
            }
            canShoot = false;
            StartCoroutine(shootTimer(coolDownTime));
        }
    }

    IEnumerator shootTimer(float time){
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
    
    void Action(){
        
    }

    void ShootLightning(){
        GameObject go = Instantiate(lightningBolt, this.transform.position, Quaternion.identity);
        WizardLightning lightning = go.GetComponent<WizardLightning>();
    }
    
    void OnTriggerStay2D(Collider2D other){
        //For the Attack
        if(other.transform.tag == "Event"){
            doEvent = true;
            if(Input.GetButtonDown("Action")){
                //Do the check on the requirements
                //If we meet them run the script
                //If not dont
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "Event"){
            doEvent = false;
        }
    }

}
