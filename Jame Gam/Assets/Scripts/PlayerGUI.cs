using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGUI : MonoBehaviour
{
    CardSelect cardSelect;
    public GameObject swipeVFX;
    PlayerMovement playerMovement;
    PlaceInHand placeInHand;
    public GameObject select;
    private GameObject player;
    public float radius;
    public LayerMask enemies;
    public bool attacked;
    GameMan manager;
    //public Animator swipeAnim;



    private void Start()
    {
        player = GameObject.Find("Player");
        cardSelect = FindObjectOfType<CardSelect>();
        manager = FindObjectOfType<GameMan>();
        playerMovement = player.GetComponent<PlayerMovement>();
        placeInHand = FindObjectOfType<PlaceInHand>();
        attacked = false;
    }


    private void Update()
    {
        swipeVFX.transform.position = select.transform.position;
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
            Invoke("ResetAttack", .5f);
            attacked = true;
            swipeVFX.SetActive(true);
           // playerMovement.canMove = false;
         }

         if (Input.GetKeyDown(KeyCode.Escape))
         {
            ResetAttack();
         }
    }

    void ResetAttack()
    {
        placeInHand.selected = false;
        manager.selectionGUI.SetActive(false);
        attacked = false;
       // playerMovement.canMove = true;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(select.transform.position, radius);
    }
}
