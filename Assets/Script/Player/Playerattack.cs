
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private PlayerController playerController;
   
    private float cooldownTimer = Mathf.Infinity;

   
    private void Awake()
    {
       
        playerController = GetComponent<PlayerController>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && cooldownTimer > attackCooldown)//&& playerController.canAttack()) 
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;

    }

    private void Attack()
    {
       
        cooldownTimer = 0;
    }





}
