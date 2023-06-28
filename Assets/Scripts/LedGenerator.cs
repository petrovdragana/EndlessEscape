using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedGenerator : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay;
    
    private float timeLeft;

    private float maxHeight = -1.32f;
    private float minHeight = -4.65f;

    [SerializeField]
    private GameObject ledPrefab;
    private float newX;
    private float newY;

    // Start is called before the first frame update
    void Start()
    {
        //float randomHeight = Random.Range(minHeight, maxHeight);

        //Vector3 newPosition = transform.position;
        //newPosition.y = randomHeight;
        //transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;

        if (timeLeft <= 0 )
        {
            
                GameObject newLed = Instantiate(ledPrefab);

            float newX = Random.Range(minHeight, maxHeight);
            float newY = Random.Range(minHeight, maxHeight);


            newLed.transform.position = new Vector2(newX, newY);
            newLed.transform.parent = transform;

            
            timeLeft = spawnDelay;
            
            
        }
           
        }
}


