using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollect : MonoBehaviour
{
    public GameObject cardPrefab;
    private GameObject lootSpawn;
    CardSelect cardSelect;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        lootSpawn = GameObject.Find("LootDrops");
        gameObject.transform.SetParent(lootSpawn.transform);
        cardSelect = FindObjectOfType<CardSelect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.Play("Loot Collect");
            cardSelect.DeckHand.Add(cardPrefab);
            Instantiate(cardPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
