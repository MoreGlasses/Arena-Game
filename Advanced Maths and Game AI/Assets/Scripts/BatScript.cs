using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public GameObject health;

    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
           
            Destroy(other.gameObject);

            int probability = Random.Range(0, 7);

            if (probability == 6)
            {
                Instantiate(health, other.transform.position, Quaternion.identity);
            }
        }

        if (other.CompareTag("Spikes"))
        {

            Destroy(other.gameObject);

            int probability = Random.Range(0, 7);

            if (probability == 6)
            {
                Instantiate(health, other.transform.position, Quaternion.identity);
            }
        }
    }
}
