using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    private PlayerMovement player;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullhearts;
    public Sprite emptyhearts;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        if (player.health > numOfHearts)
        {
            player.health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < player.health)
            {
                hearts[i].sprite = fullhearts;
            } else {
                hearts[i].sprite = emptyhearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }


}
