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
    private void Start()
    {
       selectionGUI = GameObject.Find("SelectionGUI");
       playerGUI = FindObjectOfType<PlayerGUI>();
       selectionGUI.SetActive(false);

        randomSpawnPoint = Random.Range(0, 6);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint[randomSpawnPoint].transform.position, Quaternion.identity);

    }
}
