using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text ScoreTextPlayer1;
    public Text ScoreTextPlayer2;
    public Text Timer;
    public Player Player1;
    public Player Player2;
    public Image GameOverScreenImage;
    public Text Player1Wins;
    public Text Player2Wins;
    public Text TiedText;

    public Text FinalScorePlayer1;
    public Text FinalScorePlayer2;

    

    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<UIManager>();
        }
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        ScoreTextPlayer1.text = "Score: " + Player1.Score;
        ScoreTextPlayer2.text = "Score: " + Player2.Score;
        Timer.text = "Time: " + GameManager.Instance.CurrentTime;

    }

    public void GameOverScreen()
    {
        GameOverScreenImage.gameObject.SetActive(true);

        if (Player1.Score == Player2.Score)
        {
            TiedText.gameObject.SetActive(true);
            
        }
        else if (Player1.Score > Player2.Score)
        {
            Player1Wins.gameObject.SetActive(true);
        }
        else
        {
            Player2Wins.gameObject.SetActive(true);
        }

        FinalScorePlayer1.text = Player1.Score.ToString();
        FinalScorePlayer2.text = Player2.Score.ToString();



        Time.timeScale = 0;
    }
}




