using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private float shieldTimer = 5f;
    [SerializeField] private  AudioClip powerUpSound;

    public bool isShieldEnabled = false;
    public bool isSpeedEnabled = false;
    public bool istripleGunEnabled = false;
    private PlayerController playerController;
    public  GameObject tripleGuns;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                EnableShield();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DisableShield();
        }
    }


    void EnableShield()
    {
        shield.SetActive(true);

        isShieldEnabled = true;

        DisableShield();
    }

    void DisableShield()
    {
        StopCoroutine(StartDisableShield());
    }

    private IEnumerator StartDisableShield()
    {
        yield return new WaitForSeconds(shieldTimer);

        shield.SetActive(false);

        isShieldEnabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PowerUp powerUp = collision.GetComponent<PowerUp>();

        if (powerUp != null)
        {
            if (powerUp.powerupType == PowerUp.PowerupType.shield)
            {

                EnableShield();
            }
            else if (powerUp.powerupType == PowerUp.PowerupType.speed)
            {
                EnableSpeed();
            }

            if (powerUp.powerupType == PowerUp.PowerupType.tripleGuns)
            {

                EnableTripleGun();
            }
            collision.gameObject.SetActive(false);
            SoundManager.instance.PlaySound(powerUpSound);
        }
    }

    void EnableSpeed()
    {
        playerController.speed = 15;

        isSpeedEnabled = true;

        DisableSpeed();
    }

    void DisableSpeed()
    {
        StopCoroutine(StartDisableSpeed());
    }



    private IEnumerator StartDisableSpeed()
    {
        yield return new WaitForSeconds(shieldTimer);

        playerController.speed = 5;

        isSpeedEnabled = false;
    }


    void EnableTripleGun()
    {
       tripleGuns.SetActive (true);

        istripleGunEnabled = true;

        DisableTripleGun();
    }

    void DisableTripleGun()
    {
        StopCoroutine(StartDisableTripleGun());
    }



    private IEnumerator StartDisableTripleGun()
    {
        yield return new WaitForSeconds(shieldTimer);

        istripleGunEnabled = false;

        tripleGuns.SetActive(false);
    }


}
