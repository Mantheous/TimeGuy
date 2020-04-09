using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public static bool isRewinding;
    public Rigidbody2D rb;

    List<Vector2> positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire3"))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }else
        {
            Record();
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            //transform.position = positions[0];
            rb.MovePosition(positions[0]);
            positions.RemoveAt(0);
        }else
        {
            StopRewind();
        }
        
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    void StopRewind()
    {
        isRewinding = false;
    }
}
