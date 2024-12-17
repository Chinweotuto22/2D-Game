using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifetime = 1.0f; // Set this to the length of your explosion animation

    private void Start()
    {
        
    }

    void ExplosionDone()
    {
        Destroy(gameObject, lifetime);
    }


}
