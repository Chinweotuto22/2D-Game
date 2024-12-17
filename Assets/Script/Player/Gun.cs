using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int powerUpLevelRequirement = 0;
    public GameObject Bullet;

    public bool autoshoot = false;
    public float shootDelaySeconds = 0.75f;
    float delayTimer = 0;
    [SerializeField] private AudioClip firetrapSound;
    
    void Update()
    {
        

        if (autoshoot)
        {
            if(delayTimer >= shootDelaySeconds)
            {
                    Shoot();
                delayTimer = 0;
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
           
        }
        
            if (Input.GetKeyDown(KeyCode.A))
            {
                Shoot();
                SoundManager.instance.PlaySound(firetrapSound);
            }
      
    }


    public void Shoot()
    {
        Instantiate(Bullet.gameObject, transform.position, Quaternion.identity);
    }
}
