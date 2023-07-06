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

    public static float speed;

    //private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //za animaciju
        //animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (applyForce) {

            rb.velocity = Vector2.zero;

            rb.AddForce(Vector2.up * force * Led.speed);

            applyForce = false;
        }

        UpdatePingvinAngle();

    }

    public void ApplyForce()
    {
        applyForce = true;

        //za animaciju 
        //animator.SetTrigger("Flap");
    }

    public void UpdatePingvinAngle()
    {
        //Get  percentage of speed
        float percentage = Mathf.InverseLerp(-maxSpeed, maxSpeed, rb.velocity.y);

        //Determines value of angle
        float angle = Mathf.Lerp(-maxAngle, maxAngle, percentage);

        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    //private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death") //death - tag, objekat koji ima isti tag 
        {
            //disable skripte Pingvin i PlayInput
            enabled = false;
            GetComponent<PlayerInput>().enabled = false;

            //disable collider - sve komponente su na istom objektu
            GetComponent<BoxCollider2D>().enabled = false;

            //animacija kada pingvin pogine
            rb.velocity = Vector2.zero; //velocity koji utice na brzinu kretanja ptice i multivektor
            rb.AddForce(Vector2.up * force * 1.5f); //funkcija za dodavanje sile 

            //zaustavljanje kretanja 
            Pingvin.speed = 0.0f;

            //game over prikaz
            GameManager.GameOver();

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CommonMethod(collision);
    }

    private void CommonMethod(Collider2D collider)
    {
        if (collider.gameObject.tag == "Death")
        {
            //disable skripte Pingvin i PlayInput
            enabled = false;
            GetComponent<PlayerInput>().enabled = false;

            //disable collider - sve komponente su na istom objektu
            GetComponent<BoxCollider2D>().enabled = false;

            //animacija kada pingvin pogine
            rb.velocity = Vector2.zero; //velocity koji utice na brzinu kretanja ptice i multivektor
            rb.AddForce(Vector2.up * force * 1.5f); //funkcija za dodavanje sile 

            //zaustavljanje kretanja 
            Pingvin.speed = 0.0f;

            //game over prikaz
            GameManager.GameOver();
        }
    }
}



