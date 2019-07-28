using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLightning : MonoBehaviour
{
    public float magic = 1; //Magic used
    public int direction = 1;

    public float speed = 10;
    public float lifetimeMultiplier = 1;
    public float stunDurationMultiplier = 1;
    public float life = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        
        this.transform.Translate(Vector2.left * speed * -direction * Time.deltaTime);
    }

    float calcStunTime(){
        return magic * stunDurationMultiplier; //In Seconds
    }

    IEnumerator deathTimer(float time){
        yield return new WaitForSeconds(time);
        DestroyImmediate(this.gameObject);
    }

    public float calcLifetime(){
        life =  magic * lifetimeMultiplier;
        StartCoroutine(deathTimer(life));
        return life;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.transform.tag == "Player")
            return;
        //and stun the enemy for a certain amount of time
        if(coll.transform.tag == "Enemy"){
            EnemyBase e = coll.GetComponent<EnemyBase>();
            e.stunDuration = calcStunTime();
        }
        DestroyImmediate(this.gameObject);
    }
}
