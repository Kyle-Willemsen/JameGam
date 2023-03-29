using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceInHand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameObject deckHand;

    private Vector2 originalSize;
    private Vector2 highlightedSize;
    private Vector2 selectedSize;

    public bool selected;

    void Start()
    {
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
    }
}
