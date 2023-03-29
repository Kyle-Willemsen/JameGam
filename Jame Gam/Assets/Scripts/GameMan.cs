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
    int spawnNum;

    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        spawnNum = 1;
        EnemyMovement enemyMovement = FindObjectOfType<EnemyMovement>();
        enemyMovements.Add(enemyMovement);

        selectionGUI = GameObject.Find("SelectionGUI");
        playerGUI = FindObjectOfType<PlayerGUI>();
        selectionGUI.SetActive(false);

        randomSpawnPoint = Random.Range(0, 6);
    }


    private void Update()
    {
        if (playerMovement.totalCounter <= 60)
        {
            playerMovement.enemySpawnCounter = 6;
        }
        if (playerMovement.totalCounter <= 30)
        {
            playerMovement.enemySpawnCounter = 3;
        }
        if (playerMovement.totalCounter <= 0)
        {
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

    public void WinGame()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
