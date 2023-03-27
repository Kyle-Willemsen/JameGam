using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public float radius;
    EnemyMovement enemyMovement;
    public LayerMask enemies;
    private GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckForEnemies();
           // Destroy(this.gameObject);
        }
    }
    private void CheckForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, radius, enemies);
        foreach (Collider2D obj in colliders)
        {
            if (obj.GetComponent<EnemyMovement>())
            {
                obj.GetComponent<EnemyMovement>().StopEnemy();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(player.transform.position, radius);
    }


}
