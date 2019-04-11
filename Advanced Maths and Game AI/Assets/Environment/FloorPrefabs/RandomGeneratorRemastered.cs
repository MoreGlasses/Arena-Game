using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneratorRemastered : MonoBehaviour
{

    
    public int enemyAmount = 10;

    public GameObject[] tiles;
    public List<Vector3> createdTiles;
    public int numberOfTiles;
    public int tileSize;
    public float waitTime;

    public float upProbability;
    public float rightprobability;
    public float downProbability;

    //walls

    public float minY;
    public float maxY;
    public float minX;
    public float maxX;


    private float minXSpawn = 586;
    private float minYSpawn = -90;
    private float maxXSpawn = 745;
    private float maxYSpawn = 50;

    public float xNumber;
    public float yNumber;



    void Start()
    {

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

    //&& !createdTiles.Contains(new Vector3(transform.position.x, transform.position.y + tileSize, 0))

    void MoveGenerator(int direction)
    {
        switch (direction)
        {
            case 0:
                if (transform.position.y + tileSize < maxY)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
                } else
                {
                    numberOfTiles++;
                }
                break;

            case 1:
                if (transform.position.x + tileSize < maxX)
                {
                    transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);
                } else
                {
                    numberOfTiles++;
                }
                break;

            case 2:
                if (transform.position.y - tileSize > minY)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);
                } else
                {
                    numberOfTiles++;
                }
                break;

            case 3:
                if (transform.position.x + tileSize > minX)
                {
                    transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);
                } else
                {
                    numberOfTiles++;
                }
                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if (!createdTiles.Contains(transform.position) && !(transform.position.x > minXSpawn && transform.position.x < maxXSpawn && transform.position.y > minYSpawn && transform.position.x > maxYSpawn))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;

            createdTiles.Add(tileObject.transform.position);

        }
        else
        {
            numberOfTiles++;
        }


    }

    
}
