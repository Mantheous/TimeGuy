using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SmasherMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool smashing = false;
    Transform saveLoc;
    public Animator animator;
    public GameObject death;
    public float forceMult;
    bool go;

    private void Start()
    {
        saveLoc = transform;
    }
    void Update()
    {
        if (!smashing)
        {
            rb.MovePosition(saveLoc.position);
            animator.SetBool("Smashing", false);
            rb.gravityScale = 0;
            go = false;
        }else
        {
            StartCoroutine(Smash());
        }
    }

    private void FixedUpdate()
    {
        if(go)
            rb.velocity = transform.up * -forceMult * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            smashing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            smashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && smashing)
        {
            GameObject effect = Instantiate(death, transform.position, transform.rotation);
            Destroy(effect, 0.1f);
        }
    }

    IEnumerator Smash()
    {
        animator.SetBool("Smashing", true);
        yield return new WaitForSeconds(0.5f);
        go = true;
        
    }
}
