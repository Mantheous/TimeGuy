using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door : MonoBehaviour
{

    public bool locked;
    //public bool RequireButton;

    public Animator Screw;
    public Animator Base;
    public Animator Base2;
    // Start is called before the first frame update
    void Start()
    {
        if(!locked)
        {
            Base.SetBool("Locked", false);
            Base2.SetBool("Locked", false);
        }
        else
        {
            Base.SetBool("Locked", true);
            Base2.SetBool("Locked", true);
        }
        Close();
    }

    public void Open()
    {
        //Debug.Log("Open Sesamy");
        Screw.SetBool("Open", true);
        Base.SetBool("Locked", false);
        Base2.SetBool("Locked", false);
        locked = false;
    }

    public void Close()
    {
        Screw.SetBool("Open", false);
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!locked)
            {
                Open();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Close();
        }
    }
}
