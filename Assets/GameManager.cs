using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreTextSetup;
    public Text highScoreText;
    public Text highScoreTextSetup;
    public int score = 0; 
    public GameObject borderLeft;
    public GameObject borderRight;
    public GameObject borderUp;
    public GameObject borderDown;
    Vector3 screen;
    public GameObject snake; 
    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
        BoundryCreation();
    }

    // Update is called once per frame
    void Update()
    {
        Score();
        HighScore();
        OpenMenu();
    }
    void BoundryCreation()
    {
        borderLeft.transform.localPosition = new Vector2(screen.x+ 0.3f, 0);
        borderRight.transform.localPosition = new Vector2(-screen.x - 0.3f, 0);
        borderUp.transform.localPosition = new Vector2(0, screen.y+0.3f);
        borderDown.transform.localPosition = new Vector2(0, -screen.y-0.3f);

        scoreTextSetup.transform.position = new Vector2(screen.x + 50f, screen.y + 475f);
        highScoreTextSetup.transform.position = new Vector2(screen.x + 75f, screen.y + 440f);

        borderLeft.transform.localScale = new Vector2(0.5f, screen.y*2);
        borderRight.transform.localScale = new Vector2(0.5f, screen.y*2);
        borderUp.transform.localScale = new Vector2(screen.x*2, 0.5f);
        borderDown.transform.localScale = new Vector2(screen.x*2, 0.5f);


    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name) ;
    }
    public void Quit()
    {
        Application.Quit();
    }
    void Score()
    {
        scoreText.text = "" + score; 
    }
    void HighScore()
    {
        highScoreText.text = "" + PlayerPrefs.GetInt("HighScore");
    }
    
    public void SetHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        else
        {
            return; 
        }
    }
    public void GetHighScore()
    {
        PlayerPrefs.GetInt("HighScore");
    }
    void OpenMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SetHighScore();
            SceneManager.LoadScene(0);
        }
    }

    
}
