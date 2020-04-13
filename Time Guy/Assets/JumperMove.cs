﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : MonoBehaviour
{
    public Rigidbody2D rb;
    Transform playerPos;
    public float jumpheight;
    public float jumpDis;
    public bool grounded;
    float jumpDisF;
    bool forward;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void FixedUpdate()
    {
        if(transform.position.x < playerPos.position.x)
        {
            forward = true;
            
            jumpDisF = -jumpDis;
            jumpDisF += playerPos.position.x - transform.position.x;
        }
        else
        {
            forward = false;
            
            jumpDisF = jumpDis;
            jumpDisF -= playerPos.position.x - transform.position.x;
        }
        
        if(grounded)
        {
            if(forward)
                transform.localScale = new Vector3(-5, 5, 1);
            else
                transform.localScale = new Vector3(5, 5, 1);

            //Jump up
            rb.AddForce(new Vector2(jumpDisF, jumpheight));

            
            grounded = false;
        }
    }

    public void groundSet(bool ground_)
    {
        grounded = ground_;
        //Debug.Log("groundSet");
    }
}
