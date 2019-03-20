using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public Transform spawnSpots;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;

    }
    void Update()
    {
        if(timeBetweenSpawns <= 0)
        {
            spawnSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(enemy, spawnSpots.position, Quaternion.identity);
            timeBetweenSpawns = 5;

        } else
        {
            timeBetweenSpawns -= Time.deltaTime;

        }
    }

}
