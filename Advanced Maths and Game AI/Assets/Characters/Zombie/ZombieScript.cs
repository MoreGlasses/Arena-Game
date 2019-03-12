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

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }

}



