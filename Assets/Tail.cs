using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tail : MonoBehaviour
{
    float offsetX = 0.5f;
    float offsetY = 0.5f;


    int tailNum = 0;
    GameObject[] snakeTail;
    public GameObject tail;
    public GameObject snake;
    Snake snakeScript;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        snakeTail = new GameObject[70];
        snakeTail[0] = snake;
        snakeScript = snake.GetComponent<Snake>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        tailMovement();
      // Collision(snake.transform.position.x, snake.transform.position.y);
    }

    public void AddTail()
    {
        Vector3 offset = new Vector3(offsetX * snakeScript.Direction[0], offsetY * snakeScript.Direction[1], 0);
        GameObject spawnTail = Instantiate(tail, snake.transform.position - offset, Quaternion.identity);
        offsetX = offsetX + 0.5f;
        offsetY = offsetY + 0.5f;
        if (tailNum == 0)
        {
            spawnTail.GetComponent<BoxCollider2D>().enabled = false; 
        }
        snakeTail[tailNum + 1] = spawnTail;
        spawnTail.name = "Tail" + tailNum;
        tailNum++;
    }

    public void tailMovement()
    {
        if (tailNum > 0)
        {
            for (int i = tailNum; i > 0; i--) //Go through the array in reverse to find a place to put the last piece in when the first piece moves.
            {

                //snakeTail[i].transform.SetPositionAndRotation(new Vector3(snakeTail[i - 1].transform.position.x, snakeTail[i - 1].transform.position.y, 0), Quaternion.identity);
                snakeTail[i].transform.position = snakeTail[i - 1].transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.tag);
        if (collision.tag == "Eye")
        {
            gameManager.SetHighScore(); 
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // print("Game Over");
        }
    }
}
    
    /*
    private void Collision(float snakeposX, float snakeposY)
    {
        float distance = Mathf.Sqrt(Mathf.Pow((snakeposX - this.transform.position.x), 2.0f) - Mathf.Pow((snakeposY - this.transform.position.y), 2.0f));
        if (distance < (0.5 / 2))
        {
            SceneManager.LoadScene(0);
        }
    }
}  */
