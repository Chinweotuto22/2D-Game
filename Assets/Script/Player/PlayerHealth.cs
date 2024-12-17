using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    [SerializeField] private int currentHealth;
    private PowerUpHandler powerUpHandler;
    [SerializeField] private AudioClip dealthSound;
    [SerializeField] private AudioClip hurtSound;
    private UIManager uiManager;


    private void Awake()
    {
         powerUpHandler = GetComponent<PowerUpHandler>();
         uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        // Initialize player health
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    // This method handles the player getting hit by an enemy bullet
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();

            uiManager.GameOver();

        }
        if(currentHealth < 3)
        {
            SoundManager.instance.PlaySound(hurtSound);
        }
    }

   
    void Die()
    {
        // Add logic for player death, e.g., play death animation, show game over screen
        Debug.Log("Player Died");
        Destroy(gameObject); // Destroy the player GameObject

       // GameManager.instance.GameOver();

        SoundManager.instance.PlaySound(dealthSound);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision object is an enemy bullet
        EnemyBullet bullet = collision.GetComponent<EnemyBullet>();
        if (bullet != null && bullet.isEnemy)
        {
            if (powerUpHandler.isShieldEnabled == false)
            {
                TakeDamage(1); // Assume each bullet does 1 damage
            }
            
            Destroy(bullet.gameObject); // Destroy the bullet
        }
    }
}
