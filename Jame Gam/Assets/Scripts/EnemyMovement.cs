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

    public GameObject playerTarget;
    public bool hasMoved = true;
    public bool canMove;
    public float waitMoves;
    public bool playerHasMoved;
    [SerializeField]
    Vector3 direction;
    int timesTested;

    private bool stunned;


    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("PlayerMovePoint");
        playerMovement = FindObjectOfType<PlayerMovement>();
        movePoint.parent = null;
        canMove = true;
        playerHasMoved = false;
    }

    public void Update()
    {
        direction = (playerTarget.transform.position - transform.position);
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
        }
        if (hasMoved == false)
        {
            timesTested++;
            if (timesTested == 2)
            {
                hasMoved = true;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, enemySpeed * Time.deltaTime);


        if (playerHasMoved && canMove)
        {
            switch (movementDirection)
            {
                case 1:
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, barricade))
                    {
                        movePoint.position += new Vector3(1f, 0f, 0f);

                        hasMoved = true;
                        playerHasMoved = false;
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

                        hasMoved = true;
                        playerHasMoved = false;
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

                        hasMoved = true;
                        playerHasMoved = false;
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

                        hasMoved = true;
                        playerHasMoved = false;
                    }
                    else
                    {
                        movementDirection = Random.Range(1, 2);
                        hasMoved = false;

                    }
                    break;
            }

        }
        if (stunned)
        {
            canMove = false;
            if (playerMovement.canMove == false)
            {
                waitMoves--;
                if (waitMoves <= 0)
                {
                    canMove = true;
                    waitMoves = 3;
                }
            }
        }
    }

    public void StopEnemy()
    {
        Debug.Log("Stunned");
        stunned = true;
    }
}