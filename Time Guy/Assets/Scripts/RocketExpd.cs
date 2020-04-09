using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExpd : MonoBehaviour
{
    public GameObject boom;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.GetComponent<BadGuyDie>() != null)
        {
            hit.GetComponent<BadGuyDie>().takeHit();
        }
        GameObject effect =Instantiate(boom, transform.position, transform.rotation);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
