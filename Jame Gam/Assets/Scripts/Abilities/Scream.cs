using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    private GameObject player;
    public PlaceInHand placeInHand;
    private CardSelect cardSelect;
    //PlayerMovement playerMovement;

    public float radius;
    public LayerMask enemies;
    Animator anim;
    //EnemyMovement enemyMovement;


    private void Start()
    {
        player = GameObject.Find("Player");
        //playerMovement = player.GetComponent<PlayerMovement>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
        cardSelect = FindObjectOfType<CardSelect>();
    }

    private void Update()
    {
        if (placeInHand.selected)
        {
            ScreamAttack();

            //playerMovement.canMove = false;
            anim.SetBool("Scream", true);
            //cardSelect.DeckHand.RemoveAt(0);
            Destroy(this.gameObject);
        }
    }



    public void ScreamAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, radius, enemies);
        foreach (Collider2D obj in colliders)
        {
            if (obj.GetComponent<EnemyStats>())
            {
                obj.GetComponent<EnemyStats>().StopEnemy();
            }
           // else
           // {
           //     return;
           // }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(player.transform.position, radius);
    }
}
