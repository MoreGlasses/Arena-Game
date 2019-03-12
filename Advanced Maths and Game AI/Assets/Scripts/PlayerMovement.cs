using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    
    public float speed = 50f;
    float walkinghorizontal, walkingvertical;
    public bool facingRight = true;
    public float RotateSpeed = 3.0F;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
 

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        walkinghorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        walkingvertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;


        //Player to move left, right, up, down
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * speed, Space.World);


        if (walkinghorizontal < 0 && facingRight) Flip();
        if (walkinghorizontal > 0 && !facingRight) Flip();

        if (walkinghorizontal != 0 || walkingvertical !=0 )
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        

    }

    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}