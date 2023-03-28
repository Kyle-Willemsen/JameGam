using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public float radius;
    EnemyMovement enemyMovement;
    public LayerMask enemies;
    private GameObject player;
    public PlaceInHand placeInHand;


    private void Start()
    {
        
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (placeInHand.selected)
        {
            ScreamAttack();
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
