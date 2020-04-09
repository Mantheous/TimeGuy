using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Button : MonoBehaviour
{
    public bool CanClose;
    public Door door;
    public string typeTag;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == typeTag)
        {
            door.Open();
            animator.SetBool("Pressed", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == typeTag)
        {
            if(CanClose)
            {
                door.Close();
            }
            animator.SetBool("Pressed", false);
        }
    }
}
