using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxLives;
    public float currentLives;
    public GameObject lifeImage;
    //PlayerMovement playerMovement;
    Animator anim;
    //public List<GameObject> lives = new List<GameObject>();

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentLives = maxLives;
        //playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (currentLives <= 0)
        {
            Time.timeScale = 0;
        }

        //if (curr)
    }
    public void GetHit()
    {
        currentLives--;
        //lives.Remove(lifeImage);
    }

    public void EndScreamAnim()
    {
        anim.SetBool("Scream", false);
       // playerMovement.canMove = true;
    }

    public void EndSlam()
    {
        anim.SetBool("Slam", false);
        //playerMovement.canMove = true;
    }
}
