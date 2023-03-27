using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollect : MonoBehaviour
{
    public GameObject cardPrefab;
    private GameObject lootSpawn;
    CardSelect cardSelect;


    private void Start()
    {
        lootSpawn = GameObject.Find("LootDrops");
        gameObject.transform.SetParent(lootSpawn.transform);
        cardSelect = FindObjectOfType<CardSelect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cardSelect.DeckHand.Add(cardPrefab);
            Instantiate(cardPrefab, transform.position, Quaternion.identity);
            //cardPrefab.transform.SetParent(hand);
            Destroy(this.gameObject);
        }
    }
}
