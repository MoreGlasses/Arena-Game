using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;

    public Text healthDisplay;
    public float speed = 50f;
    float walkinghorizontal, walkingvertical;
    public bool facingRight = true;
    public float RotateSpeed = 3.0F;
    public int health = 3;
    public GameObject deathAnim;
    public Text countText;
    public int kills;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetCountText();
        kills = 0;
    }
 

    void Update()
    {
        healthDisplay.text = "HEALTH : " + health;

        //if (health <= 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        if (health <= 0)
        {

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Game Over");
        }

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

        SetCountText();

    }

    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void SetCountText()
    {
        countText.text = kills.ToString();
    }
}