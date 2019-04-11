using UnityEngine;
using System.Collections;

public class DemonScript : MonoBehaviour
{
    public float speed;
    public float health;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private Transform playerPos;
    private Transform wallPos;
    private PlayerMovement player;
    private SpriteRenderer sr;
    public GameObject projectile;
    public GameObject deathAnim;

    public int numOfHearts;
    public SpriteRenderer[] hearts;
    public Sprite fullhearts;
    public Sprite emptyhearts;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        wallPos = GameObject.FindGameObjectWithTag("Wall").GetComponent<Transform>();
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

        if (this.health > numOfHearts)
        {
            this.health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < this.health)
            {
                hearts[i].sprite = fullhearts;
            }
            else
            {
                hearts[i].sprite = emptyhearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
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
                player.kills++; 
                Destroy(gameObject);

            }

        }
    }
}