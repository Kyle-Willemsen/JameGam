using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float maxLives;
    public float currentLives;
    //public GameObject lifeImage;
    //PlayerMovement playerMovement;
    Animator anim;
    //public List<GameObject> lives = new List<GameObject>();
    private GameObject loseScreen;
    GameMan manager;
    private TextMeshProUGUI liveLives;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        liveLives = GameObject.Find("remaining").GetComponent<TextMeshProUGUI>();
        manager = GameObject.Find("GameManager").GetComponent<GameMan>();
        loseScreen = manager.loseScreen;
        anim = GetComponent<Animator>();
        currentLives = maxLives;
        //playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        liveLives.text = "" + currentLives;
        if (currentLives <= 0)
        {
            // audioManager.Play("Player Death");
            Time.timeScale = 0;
            loseScreen.SetActive(true);

        }

        //if (curr)
    }


    public void GetHit()
    {
        currentLives--;
        Shake();
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

    public void Shake()
    {
        CamShake.Instance.StartShake(2f, .15f);
    }
}
