using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyDie : MonoBehaviour
{
    public float health;
    public Door door;
    public bool openDoor;
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void takeHit()
    {
        health--;
        if(health == 0)
        {
            if(openDoor)
            {
                door.Open();
            }
            //DeathAnimation
            Destroy(gameObject);
        }
    }
}
