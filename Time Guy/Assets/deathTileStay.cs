using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTileStay : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.position = GetComponentInParent<Transform>().position;
        //rb.MovePosition(GetComponentInParent<Transform>().position);
    }
}
