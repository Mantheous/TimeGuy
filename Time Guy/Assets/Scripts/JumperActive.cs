using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperActive : MonoBehaviour
{
    public JumperMove jumperMove;
    //public float pushback;
    //bool forward;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            jumperMove.activeSet(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            jumperMove.activeSet(false);
    }
}
