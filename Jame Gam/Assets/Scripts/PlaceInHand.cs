using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInHand : MonoBehaviour
{
    private GameObject deckHand;


    void Start()
    {
        deckHand = GameObject.Find("DeckHand");
        gameObject.transform.SetParent(deckHand.transform);
    }
}
