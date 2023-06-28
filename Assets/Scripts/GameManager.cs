using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score;

    [SerializeField]
    private Text scoreText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance.scoreText.text = instance.score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncrementScore()
    {
        instance.score++;

        //ispisi score na ekranu
        instance.scoreText.text = instance.score.ToString();
    }
}
