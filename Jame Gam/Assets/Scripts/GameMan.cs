using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    public PlayerGUI playerGUI;
    //Swipe swipe;
    //GroundSlam groundSlam;
    //Scream scream;
    //
    [HideInInspector] 
    public GameObject selectionGUI;
    //public Button attackButtonCD;
    //public bool attacked;
    //public int currentSwitch;


    private void Start()
    {
       selectionGUI = GameObject.Find("SelectionGUI");
       playerGUI = FindObjectOfType<PlayerGUI>();
       selectionGUI.SetActive(false);
       // attackButtonCD.interactable = false;
       // attacked = false;
    }

    private void Update()
    {

    }

   // public void Attack()
   // {
   //     switch(currentSwitch)
   //     {
   //         case 1:
   //             playerGUI.Attack();
   //             attacked = true;
   //             break;
   //
   //         case 2:
   //             groundSlam = FindObjectOfType<GroundSlam>();
   //             groundSlam.Slam();
   //             break;
   //
   //         case 3:
   //             scream = FindObjectOfType<Scream>();
   //             scream.ScreamAttack();
   //             break;
   //
   //     }
   // }
}
