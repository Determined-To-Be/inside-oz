using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLightning : MonoBehaviour
{
    public int magic = 1;
    public int direction = 1;

    public float speedBase = 1;
    public float speedMultiplier = 1;
    public float speed = 1;
    public float lifetime = 1;
    public float stunDuration = 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = speedBase + magic * speedMultiplier;
    }

    // Update is called once per frame
    void Update(){
        this.transform.Translate(Vector2.left * speed * direction * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll){
        //Destroy the lightning bolt
        //and stun the enemy for a certain amount of time
    }
}
