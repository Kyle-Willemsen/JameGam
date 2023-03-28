using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    public PlaceInHand placeInHand;
    public float radius;
    private GameObject player;
    public LayerMask enemies;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (placeInHand.selected)
        {
            Slam();
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
