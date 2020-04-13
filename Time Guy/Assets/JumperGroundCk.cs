using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperGroundCk : MonoBehaviour
{
    public JumperMove jumperMove;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
            jumperMove.groundSet(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
            jumperMove.groundSet(false);
    }
}
