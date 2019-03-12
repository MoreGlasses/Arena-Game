using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Transform[] spawnSpots;
    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;

    }
    void Update()
    {
        if(timeBetweenSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length - 1);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            timeBetweenSpawns = 2;
        } else
        {
            timeBetweenSpawns -= Time.deltaTime;

        }
    }

}
