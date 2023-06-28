using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pingvin : MonoBehaviour
{
    private bool applyForce;

    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float maxAngle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (applyForce) { 

            rb.velocity = Vector2.zero;

            rb.AddForce(Vector2.up * force);

            applyForce = false;
            }

        UpdatePingvinAngle(); 

    }

    public void ApplyForce()
    {
        applyForce = true;
    }

   public void UpdatePingvinAngle()
    {
        //Get  percentage of speed
        float percentage = Mathf.InverseLerp(-maxSpeed, maxSpeed, rb.velocity.y);

        //Determines value of angle
       float angle = Mathf.Lerp(-maxAngle, maxAngle, percentage);

        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
