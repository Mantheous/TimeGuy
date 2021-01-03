using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    public float slowdownFactor = 0;
    public float scale;

    private void Start()
    {
        slowdownFactor = 1;
        Time.timeScale = slowdownFactor;
        //doSlow(0.5f);
    }
    private void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            speedUp();
            //doSlow(1 * scale);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            slowdown();
            //doSlow(-1 * scale);
        }
        
        //doSlow(Input.GetAxis("Vertical") * scale);
    }

    public void doSlow(float slowChange)
    {
        if (slowdownFactor < 1.1 && slowdownFactor > 0.4)
        {
            slowdownFactor += slowChange;
            Time.timeScale = slowdownFactor;
            //Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }else
        {
            Debug.Log("Timefailure");
            Debug.Log(slowdownFactor);
            /*
            if (slowdownFactor > 1)
            {
                slowdownFactor += -0.1f;
            }else
            {
                slowdownFactor += 0.1f;
            }
            */
            Time.timeScale = slowdownFactor;
            //Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        
    }

    void slowdown()
    {
        if(slowdownFactor > 0.5)
        {
            slowdownFactor -= scale;
            Time.timeScale = slowdownFactor;
        }
    }

    void speedUp()
    {
        if(slowdownFactor < 1)
        {
            slowdownFactor += scale;
            Time.timeScale = slowdownFactor;
        }
    }
}
