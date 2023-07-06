using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //jedinstven, imam jednu instancu
    public static GameManager instance;
    private int score;

    [SerializeField]
    public Text scoreText;

    [SerializeField]
    private GameObject gameOverOverlay;

    [SerializeField]
    private TMPro.TextMeshProUGUI gameOverScore;

    [SerializeField]
    private TMPro.TextMeshProUGUI gameOverHighscore;


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
        InvokeRepeating("IncreaseScore", 2f, 2f);
        instance.scoreText.text = instance.score.ToString();

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncrementScore();
        }
    }

    public static void IncrementScore()
    {
        //ispisi score na ekranu
         instance.score++;
         instance.scoreText.text = instance.score.ToString();

    }

    public static void GameOver()
    {
        //score u igrici ne bude vidljiv prilikom zavrsetka igre
        instance.scoreText.gameObject.SetActive(false);

        //score na samom ekranu gameover
        instance.gameOverScore.text = "Score: " + instance.score.ToString();

        //najveci score
        int highscore = PlayerPrefs.GetInt("Highscore");
        if (instance.score > highscore)
        {  
            highscore = instance.score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        instance.gameOverHighscore.text = "High score:" + highscore.ToString();

        //vidljivost gameover ekrana
        instance.gameOverOverlay.SetActive(true);
    }

    public void PlayAgain()
    {
        //resetovanje scene na pocetak
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void IncreaseScore()
    {
        score++;
        
    }

  
}
