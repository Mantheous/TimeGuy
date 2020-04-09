using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    public float slowdownFactor;
    public float slowlength;
    public float scale;

    private void Start()
    {
        doSlow(100);
    }
    private void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            
            doSlow(1 * scale);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            doSlow(-1 * scale);
        }
        
        //doSlow(Input.GetAxis("Vertical") * scale);
    }

    public void doSlow(float slowChange)
    {
        if (slowdownFactor < 1 && slowdownFactor > 0.05)
        {
            slowdownFactor += slowChange;
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }else
        {
            if (slowdownFactor > 1)
            {
                slowdownFactor += -0.1f;
            }else
            {
                slowdownFactor += 0.1f;
            }
            
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        
    }
}
