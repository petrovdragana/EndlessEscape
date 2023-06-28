using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float speed;

    private float outOfRange = -200f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x - speed * Time.deltaTime;

        if (newX <= outOfRange) 
            Destroy(gameObject);
        

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);


    }
}
