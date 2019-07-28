using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{

    public float coyoteTime = 1f;
    public float moveAcceleration = .6f;

    public CharacterManager manager;
    public Animator animator;

    [Range(0, 1)]
    public float groundDampingMoving = .4f,
                 groundDampingTurning = .8f,
                 groundDampingStopping = .8f;

    [Range(0, 1)]
    public float airDampingMoving = .2f,
                 airDampingTurning = .95f,
                 airDampingStopping = .85f;
    
    public float jumpVelocity = 10f;

    public bool isGrounded = true;

    public float groundedAngle = 45;

    public float jumpBufferTime = .5f;
    public bool jumpBuffered = false;
    public float knockback = 15;

    protected Rigidbody2D rb;

    protected int direction = 1;

    public bool stopInput = false;

    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        manager = GameObject.FindObjectOfType<CharacterManager>();

        if(animator == null){
            animator = this.gameObject.AddComponent<Animator>();
        }
    }

    public void FixedUpdate()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("Vertical", rb.velocity.y);

        if(rb.velocity.y < 0 ){
            animator.ResetTrigger("jump");
        }

        
        

        if(!stopInput){
            Move();
            Jump();
        }

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, 90 + 90 * direction, this.transform.rotation.eulerAngles.z);
    }

    void OnDisable(){
        StopAllCoroutines();
        stopInput = false;
        isGrounded = false;
        jumpBuffered = false;
    }

    void Move(){
        //Change Rotation based on the last movement
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .5f)
            direction = Mathf.RoundToInt(Mathf.Sign(Input.GetAxisRaw("Horizontal")));

        //We need an acceleration and a damping value
        float xvel = rb.velocity.x;
        float dampingValue = 1;
        xvel += Input.GetAxisRaw("Horizontal") * moveAcceleration;
        if(isGrounded){
            if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(xvel)){ //Turning
                dampingValue = groundDampingTurning;
            } else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < .1f){ //Stopping
                dampingValue = groundDampingStopping;
            } else{ //Moving
                dampingValue = groundDampingMoving;
            }
        } else {
            if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(xvel)){ //Turning
                dampingValue = airDampingTurning;
                //xvel = Input.GetAxisRaw("Horizontal");
            } else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < .1f){ //Stopping
                dampingValue = airDampingStopping;
            } else{ //Moving
                dampingValue = airDampingMoving;
            }
        }

        xvel *= Mathf.Pow(1f-dampingValue, Time.deltaTime * 10f);
        


        rb.velocity = new Vector2(xvel, rb.velocity.y);
    }

    void Jump(){
        
        if(Input.GetButton("Jump") && stopInput == false){
            jumpBuffered = true;
            StartCoroutine(jumpBufferTimer(jumpBufferTime));
        }

        if(isGrounded && jumpBuffered){
            animator.SetTrigger("jump");
            jumpBuffered = false;
            StopCoroutine(coyoteCounter());
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
        }

        if((Input.GetButtonUp("Jump")) && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
    }

    IEnumerator jumpBufferTimer(float time){
        yield return new WaitForSeconds(time);
        jumpBuffered = false;
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
        avg -= (Vector2)this.transform.position;

        Debug.DrawLine(this.transform.position, (Vector2)this.transform.position + avg, Color.green);
        Debug.DrawLine(this.transform.position, (Vector2)this.transform.position + Vector2.down, Color.red);
        Debug.DrawLine((Vector2)this.transform.position + avg, (Vector2)this.transform.position + Vector2.down, Color.blue);

        if(Vector2.Angle(avg, Vector2.down) <= groundedAngle){
            if(other.transform.tag != "Enemy"){
                StopCoroutine(coyoteCounter());
                isGrounded = true;
                stopInput = false;
            }
        }

        if(other.transform.tag == "Enemy"){
            EnemyBase b = other.gameObject.GetComponent<EnemyBase>();
            if(b.damage <= 0){
                return;
            }

            if(manager.TakeDamage(b.damage)){
                
                //avg is already direction
                float a = Mathf.Sign(-avg.x); 
                rb.velocity = ((a * Vector2.right) + Vector2.up) * knockback;
                isGrounded = false;
                stopInput = true;
            }
        }
    }

    void OnCollisionExit2D(){
        if(this.gameObject.activeSelf)
            StartCoroutine(coyoteCounter());
    }
}