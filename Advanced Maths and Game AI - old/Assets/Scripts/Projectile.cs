using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector3 target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        target.z = 0;
        target.Normalize();

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {

            Destroy(gameObject);
        }

    }



    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + target * speed * Time.deltaTime;


        //if (Vector2.Distance(transform.position, target) < 0.2f)
        //{
        //    Destroy(gameObject);
        //}


    }
}