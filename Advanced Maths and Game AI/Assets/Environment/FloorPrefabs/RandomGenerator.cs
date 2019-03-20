using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public Transform parent;

    public int enemyAmount = 10;

    public GameObject[] tiles;
    public GameObject wall;
    public List<Vector3> createdTiles;
    public int numberOfTiles;
    public int tileSize;
    public float waitTime;

    public float upProbability;
    public float rightprobability;
    public float downProbability;

    //walls

    public float minY = 9999999;
    public float maxY = 0;
    public float minX = 9999999;
    public float maxX = 0;

    public float xNumber;
    public float yNumber;

    public float extraWallX;
    public float extraWallY;

    void Start()
    {
        parent = new GameObject().transform;
        parent.name = "Generated Stuff";
        StartCoroutine(GenerateArena());
    }


    IEnumerator GenerateArena()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            float direction = Random.Range(0f, 1f);
            int tile = Random.Range(0, tiles.Length);

            CreateTile(tile);
            CallMoveGenerator(direction);
            //yield return new WaitForSeconds(waitTime);

            if (i == numberOfTiles - 1)
            {
                End();
            }
        }

        yield return 0;
    }

    void CallMoveGenerator(float random)
    {
        if (random < upProbability)
        {
            MoveGenerator(0);
        }
        else if (random < rightprobability)
        {
            MoveGenerator(1);
        }
        else if (random < downProbability)
        {
            MoveGenerator(2);
        }
        else
        {
            MoveGenerator(3);
        }


    }

    void MoveGenerator(int direction)
    {
        switch (direction)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);

                break;

            case 1:
                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);

                break;

            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);

                break;

            case 3:
                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);

                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;

            createdTiles.Add(tileObject.transform.position);

            tileObject.transform.parent = parent;

        }
        else
        {
            numberOfTiles++;
        }


    }

    void End()
    {
        CreateWallValues();
        CreateWalls();
        Spawner();
    }

    void Spawner()
    {

        Instantiate(player, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);

        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemy, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
        }
    }

    void CreateWallValues()
    {
        for (int i = 0; i < createdTiles.Count; i++)
        {
            if (createdTiles[i].y < minY)
            {
                minY = createdTiles[i].y;
            }

            if (createdTiles[i].y > maxY)
            {
                maxY = createdTiles[i].y;
            }

            if (createdTiles[i].x < minX)
            {
                minX = createdTiles[i].x;
            }

            if (createdTiles[i].x > maxX)
            {
                maxX = createdTiles[i].x;
            }

            xNumber = ((maxX - minX) / tileSize) + extraWallX;
            yNumber = ((maxY - minY) / tileSize) + extraWallY;


        }
    }

    void CreateWalls()
    {
        for (int x = 0; x < xNumber; x++)
        {

            for (int y = 0; y < yNumber; y++)
            {
                if (!createdTiles.Contains(new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize))))
                {
                    GameObject wallObject = (GameObject)Instantiate(wall, new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation);

                    wallObject.transform.parent = parent;

                }
            }
        }
    }
}
