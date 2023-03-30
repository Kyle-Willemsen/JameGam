using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    [HideInInspector]
    public PlayerGUI playerGUI;
    [HideInInspector]
    public GameObject selectionGUI;

    public List<GameObject> spawnPoint = new List<GameObject>();
    public int randomSpawnPoint;
    public GameObject enemy;
    PlayerMovement playerMovement;


    public List<EnemyMovement> enemyMovements = new List<EnemyMovement>();
    public List<GameObject> lootSpawnLocations = new List<GameObject>();
    int spawnNum;
    EnemyMovement enemyMovement;
    EnemyStats enemyStats;

    public GameObject winScreen;
    public GameObject loseScreen;

    private bool canSpawnLoot = true;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        EnemyMovement enemyMovement = FindObjectOfType<EnemyMovement>();
        spawnNum = 1;
        
        enemyMovements.Add(enemyMovement);
        enemyStats = FindObjectOfType<EnemyStats>();
        selectionGUI = GameObject.Find("SelectionGUI");
        playerGUI = FindObjectOfType<PlayerGUI>();
        selectionGUI.SetActive(false);

        randomSpawnPoint = Random.Range(0, 6);
    }


    private void Update()
    {
        if (playerMovement.totalCounter == 85 && canSpawnLoot)
        {
            DropLoot();
            if (playerMovement.totalCounter == 60 && canSpawnLoot)
            {
                DropLoot();
                if (playerMovement.totalCounter <= 59)
                {
                    playerMovement.enemySpawnCounter = 4;

                    if (playerMovement.totalCounter == 45 && canSpawnLoot)
                    {
                        DropLoot();
                        if (playerMovement.totalCounter <= 29)
                        {
                            playerMovement.enemySpawnCounter = 3;

                            if (playerMovement.totalCounter == 15 && canSpawnLoot)
                            {
                                DropLoot();

                            }

                        }
                    }
                }
            }
            
          
        }

        if (playerMovement.totalCounter <= 0)
        {
            playerMovement.totalCounter = 0;
            WinGame();
        }
    }
    public void SpawnEnemy()
    {
        spawnNum++;
        GameObject enemyObject;
        enemyObject = Instantiate(enemy, spawnPoint[randomSpawnPoint].transform.position, Quaternion.identity);
        EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();
        enemyMovements.Add(enemyMovement);
        
    }

    public void DropLoot()
    {
        int randomLootLocation = Random.Range(1, 6);
        Instantiate(enemyStats.loot[enemyStats.randomCard], lootSpawnLocations[randomLootLocation].transform.position, Quaternion.identity, enemyStats.lootParent.transform);
        canSpawnLoot = false;
        Invoke("ResetLoot", 2);
    }

    private void ResetLoot()
    {
        Debug.Log("Reset");
        canSpawnLoot = true;
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
