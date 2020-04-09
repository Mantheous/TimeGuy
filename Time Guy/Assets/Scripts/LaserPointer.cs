using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public void point(Vector2 pos)
    {
        transform.position = new Vector2(pos.x, pos.y);
    }
}
