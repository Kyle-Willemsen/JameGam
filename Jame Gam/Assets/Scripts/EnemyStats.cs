using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public List<GameObject> loot = new List<GameObject>();
    EnemyMovement enemyMovement;
    PlayerStats playerStats;
    public Transform lootParent;
    
    private int randomCard;
    private Animator anim;
    PlayerMovement playerMovement;
    public bool canBeAttacked;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = FindObjectOfType<EnemyMovement>();
        playerStats = FindObjectOfType<PlayerStats>();
        anim = GetComponentInChildren<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        randomCard = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyMovement.canMove = false;
            anim.SetBool("Charge", true);
            if (playerMovement.getAttacked && collision.gameObject.tag == "Player")
            {
                anim.SetBool("Charge", false);
                anim.SetBool("Attack", true);
                //playerStats.GetHit();
                //playerMovement.getAttacked = false;
                //enemyMovement.canMove = true;
            }

        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        enemyMovement.canMove = true;
    //        anim.SetBool("Charge", false);
    //    }
    //}


    public void KillEnemy()
    {
        Instantiate(loot[randomCard], transform.position, Quaternion.identity, lootParent);
        Destroy(this.gameObject);
    }
}
