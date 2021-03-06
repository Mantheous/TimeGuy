﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TimeBody : MonoBehaviour
{
    public static bool isRewinding;
    public Rigidbody2D rb;
    public bool isKinamatic;
    public Animator animator;

    List<Vector2> positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        if(animator != null)
            animator.SetFloat("Speed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire3"))
        {
            StartRewind();
            //Debug.Log("Start Rewind");
        }
        if (Input.GetButtonUp("Fire3"))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }else
        {
            Record();
        }
    }

    void Record()
    {
        //Debug.Log("Recording");
        if(!isKinamatic)
            positions.Insert(0, transform.position);
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            //transform.position = positions[0];
            if (!isKinamatic)
            {
                rb.MovePosition(positions[0]);
                positions.RemoveAt(0);
            }
                
            if(animator != null)
            {
                animator.SetFloat("Speed", -1);
                Debug.Log("ReAnimating");
            }
                
        }else
        {
            StopRewind();
            if (animator != null)
                animator.SetFloat("Speed", 1);
        }
        
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    void StopRewind()
    {
        isRewinding = false;
    }
}
