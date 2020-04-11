using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMove : MonoBehaviour
{
    public Transform target;
    public float RotSpeed;
    public Vector3 targetLoc;
    public float MoveSpeed;
    float timer = 0;
    public float fireRate;
    public GameObject laserPrefab;
    public Transform firepoint;
    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > fireRate)
        {
            timer = 0;
            GameObject laser = Instantiate(laserPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * -bulletForce, ForceMode2D.Impulse);
            Destroy(laser, 2);
        }
    }

    private void FixedUpdate()
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 180;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * RotSpeed);

        transform.position = Vector3.MoveTowards(transform.position, targetLoc, MoveSpeed);
    }
}
