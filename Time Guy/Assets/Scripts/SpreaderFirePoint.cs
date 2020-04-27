using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreaderFirePoint : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.left * new Vector2(transform.position.x, Random.Range(-10, 10) / 10);
    }
}
