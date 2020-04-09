using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class EndGate : MonoBehaviour
{
    public Animator animator;
    public Material material;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        //Material material = timeGuy.GetComponent<SpriteRenderer>().material;
        StartCoroutine(GlowIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            animator.SetBool("End", true);
            
            
            StartCoroutine(MainMenu(collision.gameObject.GetComponent<TGmove>()));
            
        }
    }


    IEnumerator MainMenu(TGmove tgmove)
    {
        material.SetColor("_Color", color);
        float fade = 0;
        while (fade <= 1)
        {
            material.SetFloat("_Fade", fade);
            fade += 0.1f;
            yield return new WaitForSeconds(0.1f);
            if(fade > 0.1f)
            {
                tgmove.Freeze();
            }
        }
        
        yield return new WaitForSeconds(2f);
        Scene scene = SceneManager.GetActiveScene();
        /*
        if (SceneManager.GetSceneAt(scene.buildIndex + 1) == null)
        {
            scene = SceneManager.GetSceneAt(0);
        }else
        {
            scene = SceneManager.GetSceneAt(scene.buildIndex + 1);
        }
        */

        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    IEnumerator GlowIn()
    {
        material.SetColor("_Color", color);
        float fade = 1;
        while (fade > 0)
        {
            material.SetFloat("_Fade", fade);
            fade -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        material.SetFloat("_Fade", 0);
    }
}
