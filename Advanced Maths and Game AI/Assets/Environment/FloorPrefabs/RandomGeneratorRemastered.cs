using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneratorRemastered : MonoBehaviour
{

    
    
   

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

    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    private float minXWall = 9999999;
    private float minYWall = 9999999;
    private float maxXWall = 0;
    private float maxYWall = 0;

    public float xNumber;
    public float yNumber;

    public float extraWallX;
    public float extraWallY;

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
        if (!createdTiles.Contains(transform.position) )
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

    void End()
    {
        CreateWallValues();
        CreateWalls();
      
    }


    void CreateWallValues()
    {
        for (int i = 0; i < createdTiles.Count; i++)
        {
            if (createdTiles[i].y < minYWall)
            {
                minYWall = createdTiles[i].y;
            }

            if (createdTiles[i].y > maxYWall)
            {
                maxYWall = createdTiles[i].y;
            }

            if (createdTiles[i].x < minXWall)
            {
                minXWall = createdTiles[i].x;
            }

            if (createdTiles[i].x > maxXWall)
            {
                maxXWall = createdTiles[i].x;
            }

            xNumber = ((maxXWall - minXWall) / tileSize) + extraWallX;
            yNumber = ((maxYWall - minYWall) / tileSize) + extraWallY;


        }
    }

    void CreateWalls()
    {
        for (int x = 0; x < xNumber; x++)
        {

            for (int y = 0; y < yNumber; y++)
            {
                if (!createdTiles.Contains(new Vector3((minXWall - (extraWallX * tileSize) / 2) + (x * tileSize), (minYWall - (extraWallY * tileSize) / 2) + (y * tileSize))))
                {
                    GameObject wallObject = (GameObject)Instantiate(wall, new Vector3((minXWall - (extraWallX * tileSize) / 2) + (x * tileSize), (minYWall - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation);

                    

                }
            }
        }
    }
}
