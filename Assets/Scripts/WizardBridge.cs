using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBridge : EnemyBase
{

    public GameObject bridge;

    // Start is called before the first frame update
    void Start()
    {
        base.Start(); 
        damage = 0;     
    }

    // Update is called once per frame
    void Update()
    {
        if(isStunned){
            bridge.SetActive(true); 
        } else {
            bridge.SetActive(false);
        }
        base.Update();
    }
}
