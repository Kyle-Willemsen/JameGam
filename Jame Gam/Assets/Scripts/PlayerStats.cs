using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxLives;
    public float currentLives;
    public GameObject lifeImage;
    //public List<GameObject> lives = new List<GameObject>();

    private void Start()
    {
        currentLives = maxLives;
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
}
