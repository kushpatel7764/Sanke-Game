using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    bool lockA = false;
    bool lockB = false;
    GameObject snake;
    Rigidbody2D rbSnake; 
    float speed = 25f;
    public float[] Direction = new float[3];
    // Start is called before the first frame update
    void Start()
    {
        Direction[0] = 0;
        Direction[1] = 0;
        snake = this.gameObject;
        rbSnake = this.GetComponent<Rigidbody2D>();
        snake.transform.SetPositionAndRotation(new Vector3(-4, 0, 1), Quaternion.identity);
        Application.targetFrameRate = 200;
        Time.timeScale = 0.35f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HeadMove();
    }
    

    void HeadMove()
    {
        if (Input.GetKey(KeyCode.W) && !lockA)
        {
            
            Direction[0] = 0;
            Direction[1] = speed;
            Direction[2] = 90;
            lockB = false;
            lockA = true;
        }
        if (Input.GetKey(KeyCode.S) && !lockA)
        {
            Direction[0] = 0;
            Direction[1] = -speed;
            Direction[2] = 270;
            lockB = false;
            lockA = true;
        }
        if (Input.GetKey(KeyCode.A)&& !lockB)
        {
            Direction[1] = 0;
            Direction[0] = -speed;
            Direction[2] = 180;
            lockB = true;
            lockA=false;

        }
        if (Input.GetKey(KeyCode.D) && !lockB)
        {
            Direction[1] = 0;
            Direction[0] = speed;
            Direction[2] = 0;
            lockB = true;
            lockA = false;
        }
        
        rbSnake.velocity = new Vector2(Direction[0], Direction[1]);
        rbSnake.SetRotation(Direction[2]);
        
        
        /*
        float x = this.transform.position.x + Direction[0]; 
        float y = this.transform.position.y + Direction[1];
        //snake.transform.Rotate(0, 0, Direction[2], Space.World);
        //snake.transform.Translate(Direction[0] * speed, Direction[1] * speed, 0, Space.World);
        snake.transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.Euler(0, 0, Direction[2]));
        */
        
    }
    

}
