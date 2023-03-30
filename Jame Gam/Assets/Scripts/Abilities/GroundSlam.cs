using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    public PlaceInHand placeInHand;
    Animator anim;
    CardSelect cardSelect;
   // PlayerMovement playerMovement;

    public float radius;
    private GameObject player;
    public LayerMask enemies;


    private void Start()
    {
        player = GameObject.Find("Player");
        cardSelect = FindObjectOfType<CardSelect>();
        anim = player.GetComponent<Animator>();
        //playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (placeInHand.selected)
        {
            Slam();
            //playerMovement.canMove = false;
            anim.SetBool("Slam", true);
            //cardSelect.DeckHand.RemoveAt(0);
            Destroy(this.gameObject);
        }
    }

    public void Slam()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, radius, enemies);
        foreach (Collider2D obj in colliders)
        {
            if (obj.GetComponent<EnemyStats>())
            {
                obj.GetComponent<EnemyStats>().KillEnemy();
            }
            else
            {
                return;
            }
        }
    }


}
