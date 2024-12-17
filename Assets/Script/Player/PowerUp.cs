using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float min_Y, max_Y;
    public float min_X, max_X;
    public float moveSpeed = 5f;
    public float duration = 3f;

    public PowerupType powerupType;

    public enum PowerupType
    {
        shield,
        speed,
        tripleGuns,
    }
    void Update()
    {
        MovePowerUp();
        CheckIfOffScreen();

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.deltaTime;

        if (pos.x < -29)
        {
            Destroy(gameObject); //destroys the enemy when the get to -29 on the x axis 
        }

        transform.position = pos;


    }


    void MovePowerUp()
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

}
