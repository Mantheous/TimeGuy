using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TGdie : MonoBehaviour
{
    public Material material;
    public TGmove tgmove;
    public Rigidbody2D rb;
    public Color color;
    bool deathstarted = false;
    public void deathSet(bool deathTrig)
    {
        if (!deathstarted)
        {
            deathstarted = true;
            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        material.SetColor("_Color", color);
        float fade = 0;
        while (fade <= 1)
        {
            material.SetFloat("_Fade", fade);
            fade += 0.1f;
            yield return new WaitForSeconds(0.1f);
            if (fade > 0.1f)
            {
                tgmove.Freeze();
                Destroy(rb);
            }
        }


        //Reload scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathTile" || collision.gameObject.GetComponentInChildren<Transform>().gameObject.tag == "DeathTile")
        {
            StartCoroutine(DeathSequence());
        }
    }
}
