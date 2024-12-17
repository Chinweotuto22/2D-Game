
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Gun[] guns;
    bool shoot;
    GameObject shield;
    int powerUpGunLevel = 0;


    int hits = 3;
    bool invincible = false;
    float invincibleTime = 3;
    float invincibleTimer = 0;

    private bool canShoot = false;

    public float speed = 5.0f;
    public float min_Y, max_Y;
    public float min_X, max_X; 

    [SerializeField] private GameObject player_Bullet;
   // [SerializeField] private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack = true;


   


    void Start()
    {
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();

        guns = transform.GetComponentsInChildren<Gun>();

        foreach(Gun gun in guns)
        {
            //gun.isActive = true;
            if (gun.powerUpLevelRequirement != 0)
            {
                gun.gameObject.SetActive(false);
            }
        }
       
    }



    private void Update()
    {
        MovePlayer();
     
        if (invincible)
        {
            if(invincibleTimer >= invincibleTime)
            {
                invincibleTimer = 0;
                invincible= false;
               
            }
            else
            {
                invincibleTimer += Time.deltaTime;
                
            }
        }


        
    }

    void MovePlayer()
    {
        Vector3 temp = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            temp.y += speed * Time.deltaTime;
            if (temp.y > max_Y)
                temp.y = max_Y;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            temp.y -= speed * Time.deltaTime;
            if (temp.y < min_Y)
                temp.y = min_Y;
        }

     
        if (Input.GetKey(KeyCode.RightArrow))
        {
            temp.x += speed * Time.deltaTime;
            if (temp.x > max_X)
                temp.x = max_X;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            temp.x -= speed * Time.deltaTime;
            if (temp.x < min_X)
                temp.x = min_X;
        }

        transform.position = temp;
    }


    void ActivateShield()
    {
        shield.SetActive(true);
    }


    void DeactivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }

    void AddGuns()
    {
        powerUpGunLevel++;
        foreach(Gun gun in guns)
        {
            if (gun.powerUpLevelRequirement == powerUpGunLevel)
            {
                gun.gameObject.SetActive(true);
            }
        }
    }

    private void Shoot()
    {
        foreach (Gun gun in guns)
        {
            if (gun.gameObject.activeSelf)
            {
                gun.Shoot();
            }
        }
    }


    void IncreaseSpeed()
    {
        speed *= 2;
    }


    void ResetPlayer()
    {
        Destroy(gameObject);
    }



    void Hit(GameObject gameObjectHit)
    {
        if(HasShield())
        {
            DeactivateShield();
        }
        else
        {
            if(!invincible)
            {
                hits--;
                if(hits == 0)
                {
                    ResetPlayer();
                }
                else
                {
                    invincible = true;
                }
                Destroy(gameObjectHit);
            }
        }
    }


       private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
              
               Hit(bullet.gameObject);
            }
        }


        Demage demage = collision.GetComponent<Demage>();
       if(demage != null)
        {
          
           Hit(demage.gameObject);
        }

        if (collision.gameObject.CompareTag("TripleGun"))
        {
            EnableTripleGun();
            Destroy(collision.gameObject);
        }
    }
    private void EnableTripleGun()
    {
        canShoot = true;
        foreach (Gun gun in guns)
        {
            gun.gameObject.SetActive(true);
        }
        // Optional: Deactivate triple gun after some time
        Invoke(nameof(DisableTripleGun), 10f); // Disable after 10 seconds
    }

    private void DisableTripleGun()
    {
        canShoot = false;
        foreach (Gun gun in guns)
        {
            gun.gameObject.SetActive(false);
        }
    }



}

