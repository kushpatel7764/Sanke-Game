using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; 
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
    }
    void BoundryCreation()
    {
        borderLeft.transform.localPosition = new Vector2(screen.x+ 0.3f, 0);
        borderRight.transform.localPosition = new Vector2(-screen.x - 0.3f, 0);
        borderUp.transform.localPosition = new Vector2(0, screen.y+0.3f);
        borderDown.transform.localPosition = new Vector2(0, -screen.y-0.3f);


        borderLeft.transform.localScale = new Vector2(0.5f, screen.y*2);
        borderRight.transform.localScale = new Vector2(0.5f, screen.y*2);
        borderUp.transform.localScale = new Vector2(screen.x*2, 0.5f);
        borderDown.transform.localScale = new Vector2(screen.x*2, 0.5f);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0) ;
    }

    void Score()
    {
        scoreText.text = "" + score; 
    }
    

    
}
