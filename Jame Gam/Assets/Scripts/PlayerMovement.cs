using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    GameMan manager;

    public float moveSpeed;
    public Transform movePoint;
    public LayerMask barricade;
    public bool isMoving;
    public bool canMove;
    public bool getAttacked;

    public float enemySpawnCounter;
    public float currentSpawnCounter;


    private void Start()
    {
        manager = FindObjectOfType<GameMan>();
        movePoint.parent = null;

        currentSpawnCounter = enemySpawnCounter;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (canMove)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    canMove = false;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, barricade))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        isMoving = true;
                        getAttacked = true;
                        currentSpawnCounter--;
                    }
                }

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    canMove = false;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, barricade))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        isMoving = true;
                        getAttacked = true;
                        currentSpawnCounter--;
                    }
                }
            }

            if (currentSpawnCounter <= 0)
            {
                manager.SpawnEnemy();
                manager.randomSpawnPoint = Random.Range(0, 6);
                currentSpawnCounter = enemySpawnCounter; 
            }
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 0f && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 0f)
        {
            canMove = true;
        }

    }
}
