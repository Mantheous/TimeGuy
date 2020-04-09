using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public Camera cam;
    public float MaxSize;
    public float MinSize;
    public float ratio;

    // Update is called once per frame
    
    void Update()
    {
        //Vector2 mouseLoc = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseLoc = Input.mousePosition;
        Vector2 ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        float mouseDis = Vector2.Distance(ScreenCenter, mouseLoc);
        //Vector2 mouseDis = new Vector2(mouseLoc.x - ScreenCenter.x, mouseLoc.y - ScreenCenter.y);
        //float dist = Mathf.Sqrt((mouseDis.x * mouseDis.x) + (mouseDis.y * mouseDis.y));

        //Debug.Log(mouseDis);

        //float ratio = Screen.width / MaxSize;
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(mouseDis*ratio, MaxSize, MinSize));
        //Debug.Log(0 / MinSize);

    }
    
}
