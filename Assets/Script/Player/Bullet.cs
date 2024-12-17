using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1,0);
    public float speed = 15;
    [SerializeField] private float TimebeforeDestory = 2;


    public Vector2 velocity;

    public bool isEnemy = false;

    private void Start()
    {
        Destroy(gameObject, TimebeforeDestory);
    }


    private void Update()
    {
        velocity = direction * speed ;
    }



    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

}
