using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLaserConfig : MonoBehaviour
{
    public Transform light;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        light.localScale = spriteRenderer.size;
        light.position = new Vector2(transform.position.x, light.position.y + spriteRenderer.size.y * 1.5f);
    }


}
