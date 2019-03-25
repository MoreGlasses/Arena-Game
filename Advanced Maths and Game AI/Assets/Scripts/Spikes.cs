using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PlayerMovement player;
    public GameObject hitAnimation;
    public GameObject deathAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health--;
            Debug.Log(player.health);
            Instantiate(hitAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
