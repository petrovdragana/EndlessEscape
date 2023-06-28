using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Pingvin pingvin;

    // Start is called before the first frame update
    void Start()
    {
        pingvin = GetComponent<Pingvin>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                pingvin.ApplyForce();
        }
    }
}
