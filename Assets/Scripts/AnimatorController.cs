using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Rigidbody2D rigid;
    public Animator anim;


    public void Start(){
        rigid = this.GetComponent<Rigidbody2D>();
        if(anim == null){
            anim = this.GetComponent<Animator>();
        }
    }

    public void Update(){
        anim.SetFloat("Horizontal", rigid.velocity.x);
        anim.SetFloat("Vertical", rigid.velocity.y);
    }
}
