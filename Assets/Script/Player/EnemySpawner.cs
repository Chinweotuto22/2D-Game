using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 2);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
