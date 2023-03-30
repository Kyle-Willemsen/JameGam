using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public List<GameObject> loot = new List<GameObject>();
    EnemyMovement enemyMovement;
    PlayerStats playerStats;
    [HideInInspector] public GameObject lootParent;
    public AnimEvent animEvent;
    AudioManager audioManager;
    
    public int randomCard;
    private Animator anim;
    PlayerMovement playerMovement;

    public bool canAttack;
    public bool stunned;
    public bool move;

    public float radius;
    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        lootParent = GameObject.Find("LootDrops");
        enemyMovement = FindObjectOfType<EnemyMovement>();
        playerStats = FindObjectOfType<PlayerStats>();
        anim = GetComponentInChildren<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();


        canAttack = true;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(stunned);
        if (stunned == true)
        {
            canAttack = false;
            //enemyMovement.canMove = false;
            if (enemyMovement.canMove == false && playerMovement.getAttacked && move)
            {
                Debug.Log(enemyMovement.waitMoves);
                enemyMovement.waitMoves--;
                move = false;

                if (enemyMovement.waitMoves <= 0)
                {
                    enemyMovement.canMove = true;
                    move = true;
                    canAttack = true;
                    enemyMovement.waitMoves = 3;
                    stunned = false;
                    //enemyMovement.waitMoves = 100;
                }
            }
        }


        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, player);
        foreach (Collider2D obj in colliders)
        {
            if (obj.GetComponent<PlayerStats>())
            {
                audioManager.Play("Charge");
                enemyMovement.canMove = false;
                anim.SetBool("Charge", true);
                if (playerMovement.getAttacked && canAttack)
                {
                    //playerMovement.getAttacked = false;
                    //Debug.Log("Attack");
                    anim.SetBool("Charge", false);
                    anim.SetBool("Attack", true);
                    //playerStats.GetHit();
                    //playerMovement.getAttacked = false;
                    //enemyMovement.canMove = true;
                }
            }

            else
            {
                anim.SetBool("Charge", false);
                anim.SetBool("Attack", false);
            }
        }
    }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         //Debug.Log("Player Detected");
    //         
    //         if (playerMovement.getAttacked && canAttack)
    //         {
    //             //playerMovement.getAttacked = false;
    //             //Debug.Log("Attack");
    //             anim.SetBool("Charge", false);
    //             anim.SetBool("Attack", true);
    //             //playerStats.GetHit();
    //             //playerMovement.getAttacked = false;
    //             //enemyMovement.canMove = true;
    //         }
    //
    //     }
    // }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        enemyMovement.canMove = true;
    //        anim.SetBool("Charge", false);
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }

    public void KillEnemy()
    {
        audioManager.Play("Enemy Death");
        randomCard = Random.Range(0, 3);
        Debug.Log("dead");
        Instantiate(loot[randomCard], transform.position, Quaternion.identity, lootParent.transform);
        Destroy(this.gameObject);
    }



    public void StopEnemy()
    {
        stunned = true;
        //Debug.Log(stunned);
    }
}
