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

    public List<EnemyMovement> enemyMovements = new List<EnemyMovement>();
    int spawnNum;

    private void Start()
    {
        spawnNum = 1;
        EnemyMovement enemyMovement = FindObjectOfType<EnemyMovement>();
        enemyMovements.Add(enemyMovement);

        selectionGUI = GameObject.Find("SelectionGUI");
        playerGUI = FindObjectOfType<PlayerGUI>();
        selectionGUI.SetActive(false);

        randomSpawnPoint = Random.Range(0, 6);
    }

    public void SpawnEnemy()
    {
        if (spawnNum < 4)
        {
            spawnNum++;
            GameObject enemyObject;
            enemyObject = Instantiate(enemy, spawnPoint[randomSpawnPoint].transform.position, Quaternion.identity);
            EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();
            enemyMovements.Add(enemyMovement);
        }
    }
}
