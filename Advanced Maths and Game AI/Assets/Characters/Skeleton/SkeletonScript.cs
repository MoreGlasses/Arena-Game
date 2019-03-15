using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour
{
    public float speed;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public float health;
    public float radiusOfSearch;

    private Transform playerPos;
    private PlayerMovement player;
    private SpriteRenderer sr;
    public GameObject projectile;
    public GameObject deathAnim;
    public float delay = 0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        timeBetweenShots = startTimeBetweenShots;
        
    }

    private void Update()
    {

        float playerDistance = Vector2.Distance(playerPos.position, transform.position);

        if (timeBetweenShots <= 0 && playerDistance <= radiusOfSearch)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;

        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }







        if (player.transform.position.x > transform.position.x)
        {

            sr.flipX = false;

        }
        else
        {

            sr.flipX = true;

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health--;
            Debug.Log(player.health);
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
            this.health--;
            Debug.Log(this.health);
            if (this.health <= 0)
            {
                Instantiate(deathAnim, transform.position, Quaternion.identity);
                Destroy(gameObject);
               
            }

        }
    }
}