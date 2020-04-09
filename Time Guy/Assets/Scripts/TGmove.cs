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
    float fmoveSpd;
    float fjumpforce;
    public float timeSpdup;

    public Animator rightArm;
    public Animator legs;
    bool freeze = false;
    
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
            movement.y = 0;
            if (Input.GetButton("Jump"))
            {
                movement.y = 1;
            }
        }else{
            movement.y -= Time.deltaTime;
        }
        rightArm.SetFloat("Velocity", movement.y);
        legs.SetInteger("Movement", Mathf.RoundToInt(Input.GetAxis("Horizontal")));
    }

    private void FixedUpdate()
    {
        if (!freeze)
        {
            rb.velocity = new Vector2(movement.x * fmoveSpd * Time.fixedDeltaTime, movement.y * fjumpforce * Time.fixedDeltaTime);
        }
    }

    public void groundSet(bool ground_)
    {
        grounded = ground_;
        //Debug.Log("groundSet");
    }

    public void Freeze()
    {
        freeze = true;
    }
}
