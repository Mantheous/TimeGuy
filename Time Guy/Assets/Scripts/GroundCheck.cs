using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool grounded;

    [SerializeField]
    private TGmove tgmove;

    [SerializeField]
    private TGdie tgdie;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "block")
        {
            grounded = true;
            Debug.Log("Grounded1" + grounded);
            tgmove.groundSet(true);
        }
        /*
        if (collision.gameObject.tag == "DeathTile")
        {
            grounded = true;
            Debug.Log("Grounded1" + grounded);
            tgdie.deathSet(true);
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "block")
        {
            grounded = false;
            Debug.Log("Grounded1" + grounded);
            tgmove.groundSet(false);
        }
    }

    
}
