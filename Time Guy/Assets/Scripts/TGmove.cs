using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TGmove : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpd;
    public float jumpforce;
    public bool grounded;
    public bool climb;

    float fmoveSpd;
    float fjumpforce;
    public float timeSpdup;

    public Animator rightArm;
    public Animator legs;
    public Animator torso;
    bool right;
    bool freeze = false;
    bool jump;
    
    //public GroundCheck groundCheck;
    
    void Update()
    {
        
        float timeDif = Mathf.Abs(Time.deltaTime - Time.unscaledDeltaTime);
        fmoveSpd = moveSpd * (1 + (timeDif / timeSpdup));
        fjumpforce = jumpforce * (1 + timeDif);
        movement.x = Input.GetAxis("Horizontal");

        //grounded = groundReturn();

        if (grounded)
        {
            if (Input.GetButton("Jump"))
            {
               jump = true;
            }
           else
            {
                jump = false;
            }
        }

        if(climb)
        {
            movement.y = -Input.GetAxis("Vertical");
        }

        if (rb != null)
        rightArm.SetFloat("Velocity", rb.velocity.y);
        legs.SetInteger("Movement", Mathf.RoundToInt(Input.GetAxis("Horizontal")));
    }

    private void FixedUpdate()
    {
        if (!freeze || rb != null)
        {
            //rb.velocity = new Vector2(movement.x * fmoveSpd * Time.fixedDeltaTime, movement.y * fjumpforce * Time.fixedDeltaTime);
            if (!climb)
            {
                rb.gravityScale = 1;
                rb.velocity = new Vector2(movement.x * fmoveSpd * Time.fixedDeltaTime, rb.velocity.y);
            }
            else {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(movement.x * fmoveSpd * Time.fixedDeltaTime, movement.y * fjumpforce * Time.fixedDeltaTime);
                Debug.Log("climb");
            }

            if (jump && grounded)
            {
                rb.AddForce(Vector2.up * jumpforce);
            }
        }
    }

    public void groundSet(bool ground_)
    {
        grounded = ground_;
        //Debug.Log("groundSet");
    }

    public void climbSet(bool _climb, bool _right)
    {
        climb = _climb;
        right = _right;
        legs.SetBool("Climbing", climb);
        torso.SetBool("Climbing", climb);
        torso.SetBool("Right", right);
    }

    public void Freeze()
    {
        freeze = true;
    }
}
