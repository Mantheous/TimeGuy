using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject dronePrefab;
    public float pushoutForce;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer >= spawnRate)
        {
            timer = 0;
            GameObject drone = Instantiate(dronePrefab, transform.position, transform.rotation);
            drone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, pushoutForce));
        }
    }
}
