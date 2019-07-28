using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : PlatformerController
{

    public GameObject lightningBolt;
    public int maxMP = 1;
    float mpRecoveryRate = 1, mp = 0;
    bool isCharging = false;
    public float chargeSpeed = 1;
    // Start is called before the first frame update
    void Start(){
        //Get Current magic
        base.Start();
        maxMP = PlayerPrefs.GetInt("maxMP");
    }

    // Update is called once per frame
    void Update(){
//        HUDController.instance.setMP((int)mp);

        if(isCharging == false){
            mp = Mathf.Clamp(mp + mpRecoveryRate, 0, maxMP);
            
        }

        if(Input.GetButtonDown("Action")){ //Start Charging
            isCharging = true;
            StartCoroutine(ChargeLightning());
        }

        if(Input.GetButtonUp("Action")){ //Release Charge
            isCharging = false;
        }
    }
    
    float chargeMagic = 0;

    IEnumerator ChargeLightning(){
        //Start a particle effect??
        while(isCharging){
            if(mp >= 0){
                float val = 1 * Time.deltaTime;
                chargeMagic += val;
                mp -= val;
                //Charge the magic stats
            }
            yield return null;
        }
        
        isCharging = false;
        chargeMagic = 0;
    }

    void ShootLightning(){
        GameObject go = Instantiate(lightningBolt, this.transform.position, Quaternion.identity);
        WizardLightning lightning = go.GetComponent<WizardLightning>();
        lightning.magic = chargeMagic;
        lightning.calcLifetime();

        lightning.direction = direction;//Get currDirection
    }
}
