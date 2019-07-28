using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlatformerController
{

    public int maxAP = 1;
    public GameObject attackHitbox;

    // Start is called before the first frame update
    void Start(){
        base.Start();
        maxAP = PlayerPrefs.GetInt("maxAP"); //Get current courage values
    }

    // Update is called once per frame
    void Update(){
        
    }

    IEnumerator SwordSwing(){
        animator.Play("attack");
        attackHitbox.SetActive(true);
        while(this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack")){
            yield return null;
        }
        attackHitbox.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.transform.tag == "Enemy"){
            //Do Kill Enemy
        }
    }
}
