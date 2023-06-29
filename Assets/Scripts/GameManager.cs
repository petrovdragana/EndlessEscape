using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //jedinstven, imam jednu instancu
    public static GameManager instance;

    private int score;

    [SerializeField]
    private Text scoreText;

    private void Awake() //definisanje instance
    {
        if (instance != null) 
        {
            Destroy(this); //unistavamo skriptu, na tom drugom objektu nam ne treba skripta gm
        }
        else
        {
            instance = this; //nemamo instancu gm. treba nam skripti u kojoj smo da bude jedinstvena instance 
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        //konverzija stringa ce se desiti implicitno kada odradimo ovo
        //ide int u string 
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
