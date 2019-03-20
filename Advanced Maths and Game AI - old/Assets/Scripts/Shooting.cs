using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    private Transform playerPos;

    void Start()
    {
        playerPos = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(projectile, playerPos.position, Quaternion.identity);
        }
    }
}
