using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int scoreValue = 2;
    public float min_Y, max_Y;
    public float min_X, max_X;
    public float moveSpeed = 5f;
    public float shootInterval = 2f; // Time between shots
    [SerializeField] private Transform player; // Reference to the player's transform
    private float shootTimer;



    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

        shootTimer = shootInterval;
    }


    void Update()
    {
      //  if (GameManager.instance.IsGameOver())
      //  {
       //     return; // Stop moving if the game is over
       /// }
       
        MoveEnemy();
        CheckIfOffScreen();
      
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform .position;

        pos.x -= moveSpeed * Time.deltaTime;

        if(pos.x < -29)
        {
            Destroy(gameObject); //destroys the enemy when the get to -29 on the x axis 
        }

        transform.position = pos;

    }


    void MoveEnemy()
    {
        // Example movement logic, you can customize it based on your game
        Vector3 temp = transform.position;
        temp.x -= moveSpeed * Time.deltaTime; // Move left

        transform.position = temp;
    }


    private void CheckIfOffScreen()
    {
        // Destroy the enemy if it leaves the screen view on the left
        if (transform.position.x < min_X)
        {
            Destroy(gameObject);
        }

    }
    
    void OnDestroy()
    {
        // Check if the ScoreManager instance exists
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddPoints(scoreValue);
        }
    }

    void OnBecameInvisible()
    {
        // Deactivate the enemy when it goes off-screen
        gameObject.SetActive(false);
    }

    
}
