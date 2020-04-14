using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyDie : MonoBehaviour
{
    public float health;
    public Door door;
    public bool openDoor;
    public bool DeathEffect;
    public bool deleteEffect;
    public GameObject deathEffect;
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
                door.Open();

            //DeathAnimation
            if(DeathEffect)
            {
                GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
                if(deleteEffect)
                {
                    Destroy(effect, 5);
                }
            }

            Destroy(gameObject);
        }
    }
}
