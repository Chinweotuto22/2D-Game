using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBorder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the border is a bullet or enemy by tag
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            // Destroy the object that collided with the border
            Destroy(other.gameObject);
        }
    }
}
