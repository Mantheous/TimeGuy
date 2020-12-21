using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool grounded;
    public bool ClimbCheck;
    public bool RightCheck;
    [SerializeField]
    private TGmove tgmove;

    [SerializeField]
    private TGdie tgdie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "block")
        {
            if (!ClimbCheck)
            {
                //ground Check
                grounded = true;
                //Debug.Log("Grounded1" + grounded);
                tgmove.groundSet(true);
            }else
            {
                //ClimbCheck
                tgmove.climbSet(true);
            }
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
            if (!ClimbCheck)
            {
                grounded = false;
                Debug.Log("Grounded1" + grounded);
                tgmove.groundSet(false);
            }else
            {
                tgmove.climbSet(false);
                Debug.Log("Stopped Climbing");
            }
                
        }
    }

    
}
