using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RocketLauncherPoint : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public Transform Guyloc;
    public Vector2 handChange;
    public Animator animator;
    public Animator body;
    int Aoutput;
    public Transform laserOrigin;
    public LaserPointer laser;
    public LayerMask laserMask;
    //Vector2 mousePos;

    void Update()
    {
        float angle = rb.rotation % 360;
        if (angle < 22.5 && angle > -22.5)
        {
            setA(0, true);
        }

        if (angle > 22.5 && angle < 67.5)
        {
            setA(1, true);
        }

        if (angle > 67.5 && angle < 112.5)
        {
            setA(2, true);
        }

        if (angle > 112.5 && angle < 157.5)
        {
            setA(3, false);
        }

        if (angle > 157.5 && angle < 202.5)
        {
            setA(4, false);
        }

        if (angle > 202.5 && angle < 247.5)
        {
            setA(5, false);
        }

        if (angle > 257.5 || angle < -67.5)
        {
            setA(6, false);
        }

        if (angle > -67.5 && angle < -22.5)
        {
            setA(7, true);
        }
        //animator.SetFloat("Angle", rb.rotation % 360);
        //body.SetFloat("Angle", rb.rotation % 360);
    }

    private void FixedUpdate()
    {
        float inx = Input.GetAxis("Horizontal1");
        float iny = Input.GetAxis("Vertical1");

        float angle = Mathf.Atan2(iny, inx) * Mathf.Rad2Deg + 90;
        if (inx !=0 && iny != 0)
        {
            rb.rotation = angle;
        }
        //Debug.Log(angle);


        Vector2 handLoc = new Vector2(Guyloc.position.x + handChange.x, Guyloc.position.y + handChange.y);
        rb.MovePosition(handLoc);

        RaycastHit2D hit = Physics2D.Raycast(laserOrigin.position, new Vector2(-iny, inx), Mathf.Infinity);
        //Debug.DrawRay(transform.position, new Vector2(inx, iny), Color.green);
        //hit.point;
        laser.point(hit.point);
        //Debug.Log(hit.point);
    }

    void setA(float output, bool forwards)
    {
        animator.SetInteger("Angle", Mathf.RoundToInt(output));
        body.SetBool("forwards", forwards);
        Debug.Log(output);
    }

    /*
    private void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 mousePos2 = new Vector2(mousePos.x, mousePos.y);
        Vector2 pointDir = mousePos - rb.position;
        float angle = Mathf.Atan2(pointDir.y, pointDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        

        Vector2 handLoc = new Vector2(Guyloc.position.x + handChange.x, Guyloc.position.y + handChange.y);
        rb.MovePosition(handLoc);
    }
    */
}
