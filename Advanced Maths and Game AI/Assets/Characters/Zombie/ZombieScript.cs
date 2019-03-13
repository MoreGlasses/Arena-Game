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
    private Transform playerPos;
    private PlayerMovement player;
    public SpriteRenderer sr;

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



