using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TGmove : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpd;
    public float climbingSpd;
    public float jumpforce;
    public bool grounded;
    public bool climb;

    float fmoveSpd;
    float climbSpd;
    float fjumpforce;
    public float timeSpdup;

    public Animator rightArm;
    public Animator legs;
    //public Animator torso;
    bool right;
    bool freeze = false;
    bool jump;
    string state = "idle";
    //public GroundCheck groundCheck;
    //public float scaledGravity;
    
    void Update()
    {
        
        float timeDif = Mathf.Abs(Time.deltaTime - Time.unscaledDeltaTime);
        fmoveSpd = moveSpd * (1 + (timeDif / timeSpdup));
        climbSpd = climbingSpd * (1 + (timeDif / timeSpdup));
        fjumpforce = jumpforce * (1 + timeDif);
        movement.x = Input.GetAxis("Horizontal");
        //scaledGravity = (Time.deltaTime / Time.unscaledDeltaTime);
        //grounded = groundReturn();

        if (grounded)
        {
            if(movement.x < 0.5)
            {
                state = "idle";
                //Debug.Log(state);

            }
            else
            {
                state = "walk";
                //Debug.Log(state);
            }
        }

        if (Input.GetButton("Jump"))
        {
            if(state != "jump")
            {
                state = "jump";
                rb.AddForce(Vector2.up * jumpforce * Time.timeScale);
                //Debug.Log(state);
            }
        }
        //Debug.Log(Time.deltaTime / Time.unscaledDeltaTime);

        if(climb)
        {
            state = "climb";
            movement.y = -Input.GetAxis("Vertical");
            //Debug.Log(state);
        }else
        {
            if(state == "climb")
            {
                state = "idle";
            }
        }

        if (rb != null)
        rightArm.SetFloat("Velocity", rb.velocity.y);
        legs.SetInteger("Movement", Mathf.RoundToInt(Input.GetAxis("Horizontal")));
    }

    private void FixedUpdate()
    {
        //Debug.Log(state);
        if (!freeze || rb != null)
        {
            if(state == "idle")
            {
                //no movement scripts

                //Walk scripts to move to other states
                rb.gravityScale = 1;
                rb.velocity = new Vector2(movement.x * fmoveSpd * Time.unscaledDeltaTime, rb.velocity.y);
            }

            if(state == "walk")
            {
                rb.gravityScale = 1;
                rb.velocity = new Vector2(movement.x * fmoveSpd * Time.unscaledDeltaTime, rb.velocity.y);
            }

            if (state == "jump")
            {
                //Jumpforce is added when it changes
                rb.gravityScale = 1;
                rb.velocity = new Vector2(movement.x * fmoveSpd * Time.unscaledDeltaTime, rb.velocity.y);
            }

            if(state == "climb") {
                //climbing
                rb.gravityScale = 0;
                rb.velocity = new Vector2(movement.x * fmoveSpd * Time.unscaledDeltaTime, movement.y * climbSpd * Time.unscaledDeltaTime);
                Debug.Log("climb");
            }
        }
    }

    public void groundSet(bool ground_)
    {
        grounded = ground_;
        Debug.Log("groundSet");
    }

    public void climbSet(bool _climb)
    {
        climb = _climb;
        legs.SetBool("Climbing", climb);
        //torso.SetBool("Climbing", climb);
        //torso.SetBool("Right", right);
        Debug.Log("ClimbSet");
    }

    public void Freeze()
    {
        freeze = true;
    }
}
