using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_timer = 3f;
    public Vector2 direction;
    public bool isEnemy = true;


    private void OnEnable()
    {
        // Start the deactivation timer when the bullet is activated
        Invoke("Deactivate", deactivate_timer);
    }

    private void OnDisable()
    {
        // Cancel the deactivation timer if the bullet is deactivated early
        CancelInvoke();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp += (Vector3)direction * speed * Time.deltaTime;
        transform.position = temp;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
