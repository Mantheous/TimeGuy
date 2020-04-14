using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperGroundCk : MonoBehaviour
{
    public JumperMove jumperMove;
    //public float pushback;
    //bool forward;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "block")
            jumperMove.groundSet(true);
        /*
        if(collision.gameObject.tag == "block")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (forward)
                rb.AddForce(new Vector2(-pushback, 0), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(pushback, 0), ForceMode2D.Impulse);
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
            jumperMove.groundSet(false);
    }
    /*
    private void Update()
    {
        if (GetComponentInParent<Transform>().localScale.x == 5)
        {
            forward = true;
        }else
        {
            forward = false;
        }
    }
    */
}
