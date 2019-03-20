using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private PlayerMovement playerHealth;
    private Vector2 target;
    public GameObject hitAnimation;
    


    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {

            Instantiate(hitAnimation, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            playerHealth.health--;
            Instantiate(hitAnimation, transform.position, Quaternion.identity);
            Debug.Log(playerHealth.health);
            DestroyProjectile();


        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
