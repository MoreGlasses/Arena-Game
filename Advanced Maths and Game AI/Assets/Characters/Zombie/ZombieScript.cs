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

    

    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    public bool facingRight = true;
    private float range;
    

    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            Debug.Log(range);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //Vector3 lookVector = target.transform.position - transform.position;
            //lookVector.y = transform.position.y;
            //Quaternion rot = Quaternion.LookRotation(lookVector);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

        }
    }

    }



