using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public int life;
    public float stunDuration;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
