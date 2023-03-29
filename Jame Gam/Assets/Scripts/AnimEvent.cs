using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public Animator anim;
    PlayerMovement playerMovement;
    public LayerMask player;
    public float radius;


    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void AttackPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, player);
        foreach (Collider2D obj in colliders)
        {
            if (obj.GetComponent<PlayerStats>())
            {
                obj.GetComponent<PlayerStats>().GetHit();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
    public void AnimEnded()
    {
        anim.SetBool("Attack", false);
        enemyMovement.canMove = true;
        playerMovement.getAttacked = false;
    }
}
