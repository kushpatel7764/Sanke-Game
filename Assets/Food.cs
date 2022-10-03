using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public class Food : MonoBehaviour
{
    public GameManager gameManager;
    public Tail tailScript; 
    GameObject food;
    public Transform snake; 
    Vector3 screen; 
    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
        food = this.gameObject; 
        food.transform.Translate(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Collision(snake.position.x, snake.position.y); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision");
        if (collision.gameObject.tag == "Player")
        {
            FoodMove();
            tailScript.AddTail();
            gameManager.score++;
          // snakeScript.TailMovement(); 
        }
    }
    /*
    private void Collision(float snakeposX, float snakeposY)
    {
        float distance = Mathf.Sqrt(Mathf.Pow((snakeposX - this.transform.position.x), 2.0f) - Mathf.Pow((snakeposY - this.transform.position.y), 2.0f));
        if (distance < (0.5/2))
        {
            FoodMove();
        }
    }
    */
    void FoodMove()
    {  
        food.transform.SetPositionAndRotation( new Vector3(Random.Range(-screen.x + (food.transform.localScale.x/2), screen.x - (food.transform.localScale.x / 2)), Random.Range(-screen.y + (food.transform.localScale.x / 2), screen.y - (food.transform.localScale.x / 2)),1), Quaternion.identity);
    }
}
