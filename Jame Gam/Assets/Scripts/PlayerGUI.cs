using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGUI : MonoBehaviour
{
    public GameObject select;
    //private GameMan manager;
    private GameObject player;
    public float radius;
    public LayerMask enemies;
    public bool attacked;



    private void Start()
    {
        //manager = FindObjectOfType<GameMan>();
        attacked = false;
        player = GameObject.Find("Player");
    }


    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.W))
         {
            select.transform.localPosition = new Vector2(0f, 1f);
         }
         if (Input.GetKeyDown(KeyCode.A))
         {
            select.transform.localPosition = new Vector2(-1f, 0f);
         }
         if (Input.GetKeyDown(KeyCode.S))
         {
            select.transform.localPosition = new Vector2(0f, -1f);
         }
         if (Input.GetKeyDown(KeyCode.D))
         {
            select.transform.localPosition = new Vector2(1f, 0f);
         }

         if (Input.GetKeyDown(KeyCode.Space))
         {
            Attack();
            attacked = true;
         }
    }

    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(select.transform.position, radius, enemies);
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
            return;
        }
    }
}
