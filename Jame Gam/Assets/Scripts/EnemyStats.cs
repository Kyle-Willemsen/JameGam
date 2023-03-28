using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    EnemyMovement enemyMovement;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = FindObjectOfType<EnemyMovement>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStats.GetHit();
        }
    }
    public void KillEnemy()
    {
        Destroy(this.gameObject);
    }
}
