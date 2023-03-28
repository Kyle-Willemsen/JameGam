using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public PlaceInHand placeInHand;
    PlayerMovement playerMovement;
    private GameMan manager;


    private void Start()
    {
        manager = FindObjectOfType<GameMan>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        if (placeInHand.selected)
        {
            playerMovement.canMove = false;
            manager.selectionGUI.SetActive(true);
            manager.attackButtonCD.interactable = true;
            if (manager.attacked)
            {
                manager.selectionGUI.SetActive(false);
                manager.attackButtonCD.interactable = false;
                Destroy(this.gameObject);
                manager.attacked = false;
            }
        }
    }
}
