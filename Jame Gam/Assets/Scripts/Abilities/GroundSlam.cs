using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    public PlaceInHand placeInHand;
    CardSelect cardSelect;

    public float radius;
    private GameObject player;
    public LayerMask enemies;


    private void Start()
    {
        player = GameObject.Find("Player");
        cardSelect = FindObjectOfType<CardSelect>();
    }

    private void Update()
    {
        if (placeInHand.selected)
        {
            Slam();
            cardSelect.DeckHand.RemoveAt(0);
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
