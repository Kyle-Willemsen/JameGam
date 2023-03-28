using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceInHand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameObject deckHand;
    GameMan manager;

    private Vector2 originalSize;
    private Vector2 highlightedSize;
    private Vector2 selectedSize;

    public bool selected;

    void Start()
    {
        manager = FindObjectOfType<GameMan>();
        selected = false;

        originalSize = new Vector2(1f, 1f);
        highlightedSize = new Vector2(1.1f, 1.1f);
        selectedSize = new Vector2(1.25f, 1.25f);

        deckHand = GameObject.Find("DeckHand");
        gameObject.transform.SetParent(deckHand.transform);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = highlightedSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = originalSize;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.transform.localScale = selectedSize;
        selected = true;

       // if (gameObject.tag == "Swipe")
       // {
       //     manager.currentSwitch = 1;
       //     Debug.Log("Swipe Selected");
       // }
       // if (gameObject.tag == "Slam")
       // {
       //     manager.currentSwitch = 2;
       //     Debug.Log("slam Selected");
       // }
       // if (gameObject.tag == "Scream")
       // {
       //     manager.currentSwitch = 3;
       //     Debug.Log("Scream Selected");
       // }
    }
}
