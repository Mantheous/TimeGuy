using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    public GameObject rocket;
    public Transform firepoint;
    public Transform firepos;
    public float bulletForce;
    int bulletCount;
    public int MaxRockets;
    void Update()
    {
        if(Input.GetButtonDown("Fire4"))
        {
            if (bulletCount <= MaxRockets)
            {
                GameObject bullet = Instantiate(rocket, firepos.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
                
            }
        }
    }


}
