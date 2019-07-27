using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{

    public float coyoteTime = 1f;
    public float horizontalAcceleration = .5f;
    public float horizontalDamping = 1;
    
    public float moveSpeed = 1;
    public float jumpVelocity = 10f;

    public bool isGrounded = true;

    public float groundedAngle = 45;


    Rigidbody2D rb;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void Move(){
        //We need an acceleration and a damping value

        float xvel = rb.velocity.x;
        xvel += Input.GetAxis("Horizontal");
        xvel *= Mathf.Pow(1f-horizontalDamping, Time.deltaTime * 10f);
        rb.velocity = new Vector2(xvel, rb.velocity.y);
    }

    void Jump(){
        if(Input.GetKeyDown("Jump")){
            StopCoroutine(coyoteCounter());
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
        }

        if(Input.GetKeyUp("Jump") && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
    }

    IEnumerator coyoteCounter(){
        yield return new WaitForSeconds(coyoteTime);
        isGrounded = false;
    }

    void OnCollisionStay2D(Collision2D other){

        Vector2 avg = new Vector2();
        foreach(ContactPoint2D c in other.contacts){
            Debug.DrawLine(this.transform.position, c.point, Color.black);
            avg += c.point;
        }
        avg /= other.contacts.Length;

        Debug.DrawLine(this.transform.position, avg, Color.green);

        if(Vector2.Angle(avg, Vector2.down) < groundedAngle){
            StopCoroutine(coyoteCounter());
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(){
        StartCoroutine(coyoteCounter());
    }
}
