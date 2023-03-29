using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    private GameObject player;
    public PlaceInHand placeInHand;
    private CardSelect cardSelect;

    public float radius;
    public LayerMask enemies;
    //EnemyMovement enemyMovement;


    private void Start()
    {
        cardSelect = FindObjectOfType<CardSelect>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (placeInHand.selected)
        {
            ScreamAttack();
            cardSelect.DeckHand.RemoveAt(0);
            Destroy(this.gameObject);
        }
    }
    public void ScreamAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, radius, enemies);
        foreach (Collider2D obj in colliders)
        {
            if (obj.GetComponent<EnemyMovement>())
            {
                obj.GetComponent<EnemyMovement>().StopEnemy();
            }
            else
            {
                return;
            }
        }
    }
}
