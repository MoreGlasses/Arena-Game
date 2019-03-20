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
    public GameObject hitAnimation;
    public float delay = 0f;

    public int numOfHearts;
    public SpriteRenderer[] hearts;
    public Sprite fullhearts;
    public Sprite emptyhearts;

    //patrol variables

    public Transform moveSpots;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float waitTime;
    public float startWaitTime;

    private bool isPatrolling;

    void Start()
    {
        waitTime = startWaitTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        timeBetweenShots = startTimeBetweenShots;

        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        isPatrolling = true;
    }

    private void Update()
    {

        float playerDistance = Vector2.Distance(playerPos.position, transform.position);

        if (timeBetweenShots <= 0 && playerDistance <= radiusOfSearch)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            isPatrolling = false;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
       
        }

        if (playerDistance >= radiusOfSearch) {
            isPatrolling = true;
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

        if (isPatrolling == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
      

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {


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