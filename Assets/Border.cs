using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Border : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public GameManager gameManager;
    GameObject border; 
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.SetHighScore(); 
            Time.timeScale = 0;
            gameOverCanvas.enabled = true;
        }
    }
}
