using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public PlaceInHand placeInHand;
    PlayerMovement playerMovement;
    //private GameObject selectionGUI;
    //PlayerGUI playerGUI;
    private GameMan manager;


    private void Start()
    {
        manager = FindObjectOfType<GameMan>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        //selectionGUI = GameObject.Find("SelectionGUI");
        //playerGUI = FindObjectOfType<PlayerGUI>();
    }
    private void Update()
    {
        if (placeInHand.selected)
        {
            playerMovement.canMove = false;
            manager.selectionGUI.SetActive(true);
            //manager.attackButtonCD.interactable = true;
            if (manager.playerGUI.attacked)
            {
                Destroy(this.gameObject);
                manager.selectionGUI.SetActive(false);
            }
        }
    }
}
