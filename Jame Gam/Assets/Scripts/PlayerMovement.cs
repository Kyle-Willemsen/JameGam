using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public float totalCounter;
    private TextMeshProUGUI stepCounter;
    AudioManager audioManager;
   [HideInInspector] public EnemyStats enemyStats;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        stepCounter = GameObject.Find("remainingSteps").GetComponent<TextMeshProUGUI>();
        manager = FindObjectOfType<GameMan>();
        movePoint.parent = null;
        enemyStats = FindObjectOfType<EnemyStats>();
        currentSpawnCounter = enemySpawnCounter;
    }

    private void Update()
    {
        stepCounter.text = "" + totalCounter;
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
                        audioManager.Play("Footsteps");
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        isMoving = true;
                        getAttacked = true;
                        currentSpawnCounter--;
                        totalCounter--;
                        enemyStats.move = true;
                        foreach (EnemyMovement i in manager.enemyMovements)
                        {
                            i.playerHasMoved = true;
                        }
                        isMoving = false;
                    }
                }

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    canMove = false;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, barricade))
                    {
                        audioManager.Play("Footsteps");
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        isMoving = true;
                        getAttacked = true;
                        currentSpawnCounter--;
                        totalCounter--;
                        enemyStats.move = true;
                        foreach (EnemyMovement i in manager.enemyMovements)
                        {
                            i.playerHasMoved = true;
                        }
                        isMoving = false;
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
            getAttacked = false;
        }

    }
}
