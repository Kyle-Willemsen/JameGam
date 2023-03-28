using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int movementDirection;
    public float enemySpeed;
    public Transform movePoint;
    public LayerMask barricade;

    public Transform playerTarget;
    public bool hasMoved = true;
    public bool canMove;
    public float waitMoves;


    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        movePoint.parent = null;
        canMove = true;
    }

    private void Update()

    {
        Vector3 direction = (playerTarget.position - transform.position);
        if (hasMoved)
        {
            if (direction.x > 0)
            {
                movementDirection = 1;
            }
            if (direction.x < 0)
            {
                movementDirection = 2;
            }
            if (direction.y > 0)
            {
                movementDirection = 3;
            }
            if (direction.y < 0)
            {
                movementDirection = 4;
            }
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, enemySpeed * Time.deltaTime);


            if (playerMovement.isMoving && canMove)
            {
                switch (movementDirection)
                {
                    case 1:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(1f, 0f, 0f);
                            playerMovement.isMoving = false;

                        }
                        else
                        {
                            movementDirection = Random.Range(3, 4);
                            hasMoved = false;
                        }
                        break;

                    case 2:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(-1f, 0f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(3, 4);
                            hasMoved = false;
                        }
                        break;

                    case 3:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(0f, 1f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(1, 2);
                            hasMoved = false;
                        }
                        break;

                    case 4:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(0f, -1f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(1, 2);
                            hasMoved = false;
                        }
                        break;
                }
            }



            if (playerMovement.isMoving && canMove)
            {
                switch (movementDirection)
                {
                    case 1:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(1f, 0f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(3, 4);
                        }
                        break;

                    case 2:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(-1f, 0f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(3, 4);
                        }
                        break;

                    case 3:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(0f, 1f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(1, 2);
                        }
                        break;

                    case 4:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(0f, -1f, 0f);
                            playerMovement.isMoving = false;
                        }
                        else
                        {
                            movementDirection = Random.Range(1, 2);
                        }
                        break;
                }
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, enemySpeed * Time.deltaTime);
            if (playerMovement.isMoving && canMove)
            {
                switch (movementDirection)
                {
                    case 1:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(1f, 0f, 0f);
                            playerMovement.isMoving = false;
                            hasMoved = true;
                        }
                        else
                        {
                            movementDirection = Random.Range(3, 4);
                        }
                        break;

                    case 2:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(-1f, 0f, 0f);
                            playerMovement.isMoving = false;
                            hasMoved = true;
                        }
                        else
                        {
                            movementDirection = Random.Range(3, 4);
                        }
                        break;

                    case 3:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(0f, 1f, 0f);
                            playerMovement.isMoving = false;
                            hasMoved = true;
                        }
                        else
                        {
                            movementDirection = Random.Range(1, 2);
                        }
                        break;

                    case 4:
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, barricade))
                        {
                            movePoint.position += new Vector3(0f, -1f, 0f);
                            playerMovement.isMoving = false;
                            hasMoved = true;
                        }
                        else
                        {
                            movementDirection = Random.Range(1, 2);
                        }
                        break;
                }
            }
        }
    }

    public void StopEnemy()
    {
        canMove = false;
       //if (playerMovement.isMoving)
       //{
       //    waitMoves--;
       //    if (waitMoves <= 0)
       //    {
       //        canMove = true;
       //        waitMoves = 3;
       //    }
       //}
    }
}