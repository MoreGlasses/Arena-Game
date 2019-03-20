using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    //public float speed;
    //public Transform player;

    //private void FixedUpdate()
    //{
    //    float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

    //    transform.eulerAngles = new Vector3(0, 0, z);

    //    GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);

    //}

    
    public float speed = 2f;
    public float health;
    private Transform playerPos;
    private PlayerMovement player;
    private SpriteRenderer sr;
    public GameObject deathAnim;

    public int numOfHearts;
    public SpriteRenderer[] hearts;
    public Sprite fullhearts;
    public Sprite emptyhearts;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            Vector3 lookVector = player.transform.position - transform.position;
            
            if (player.transform.position.x > transform.position.x)
            {

                sr.flipX = false;
                
            } else {

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
            Instantiate(deathAnim, transform.position, Quaternion.identity);
            player.kills++;
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



