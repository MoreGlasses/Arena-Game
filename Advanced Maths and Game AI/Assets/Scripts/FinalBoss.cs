using UnityEngine;
using UnityEngine.UI;   
using System.Collections;

public class FinalBoss : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private Transform playerPos;
    private PlayerMovement player;

    public GameObject projectile;
    public GameObject deathAnim;

    public GameObject healthBar;
    public Slider slider;
    private SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        timeBetweenShots = startTimeBetweenShots;

        slider.value = CalculateHealth();
    }

    private void Update()
    {

        slider.value = CalculateHealth();

        if (health <= maxHealth)
        {
            healthBar.SetActive(true);
        }

        if (Vector2.Distance(transform.position, playerPos.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, playerPos.position) < stoppingDistance && Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            // add shooting here
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, playerPos.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
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

    float CalculateHealth()
    {
        return this.health / maxHealth;
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