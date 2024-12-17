using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Demage : MonoBehaviour
{
    bool canBeDestroyed = false;
    public int scoreValue = 5;
    public GameObject explosion;
    public CameraShake cameraShake;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void Update()
    {
       // if(transform.position.x < -2)
       // {
        //    DestroyShip();
       // }
        if(transform.position.x < 17.0f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach(Gun gun in guns)
            {
               // gun.isActive = true;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!canBeDestroyed)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if(!bullet.isEnemy)
            {
                Destroy(gameObject);
              
                Destroy(bullet.gameObject);

                DestroyShip();

            }
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

    void DestroyShip()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (cameraShake != null)
        {
            cameraShake.Shake();
        }

    }

}
