using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGhook : MonoBehaviour
{
    public DistanceJoint2D joint;
    Vector3 targetPos;
    public float hookDis;
    public LayerMask hookMask;
    public Camera cam;
    public LineRenderer line;

    [SerializeField]
    private TGmove tgmove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }

        if (!Input.GetMouseButton(1))
        {
            //joint.enabled = false;
            //tgmove.groundSet(false);
        }
    }

    void Fire()
    {
        
        Debug.Log("Left");
        targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPos-transform.position, Mathf.Infinity, hookMask);

        if (hit.collider != null)
        {
            joint.enabled = true;    
            joint.connectedAnchor = hit.point;
            joint.distance = 10;
            //joint.distance = Mathf.Sqrt(Mathf.Abs(hit.point.x - transform.position.x) * Mathf.Abs(hit.point.x - transform.position.x)) + (Mathf.Abs(hit.point.y - transform.position.y) * Mathf.Abs(hit.point.y - transform.position.y));
            //tgmove.groundSet(true);
        }
        
        /*
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, hookMask);

        if (hit.collider != null)
        {
            DistanceJoint2D newRope = gameObject.AddComponent<DistanceJoint2D>();
            newRope.enableCollision = false;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;

            
            
        }
        */
    }
}
