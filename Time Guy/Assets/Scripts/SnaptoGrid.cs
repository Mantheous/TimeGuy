using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnaptoGrid : MonoBehaviour
{
    public Transform tran;
    public float snapto;
    // Start is called before the first frame update
    void Start()
    {
        tran = GetComponent<Transform>();
        transform.position = new Vector2(tran.position.x - (tran.position.x % snapto), tran.position.y - (tran.position.y % snapto));
    }
}
