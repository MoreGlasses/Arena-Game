using UnityEngine;
using System.Collections;

public class DemonScript : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    private Transform playerPos;
    private PlayerMovement player;
    public SpriteRenderer sr;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        timeBetweenShots = startTimeBetweenShots;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, playerPos.position) < stoppingDistance && Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            // add shooting here
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, playerPos.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
        }

        if(timeBetweenShots <= 0)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;

        } else
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
            Destroy(gameObject);
        }
    }
}