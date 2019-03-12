using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour
{
    public float speed = 5f;


    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}