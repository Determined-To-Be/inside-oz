using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public int life;
    public float stunDuration;
    public int damage = 1;
    public bool isStunned = false;

    // Start is called before the first frame update
    public void Start()
    {
        this.transform.tag = "Enemy";
    }

    // Update is called once per frame
    public void Update()
    {
        if(stunDuration > 0){
            isStunned = true;
            stunDuration -= Time.deltaTime;
            return;
        }
        isStunned = false;
    }

    void OnTriggerEnter2D(Collider2D coll){
        
    }


}
