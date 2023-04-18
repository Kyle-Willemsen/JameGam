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
    AudioManager audioManager;

    public bool selected;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        selected = false;

        originalSize = new Vector2(83, 83);
        highlightedSize = new Vector2(93, 93);
        selectedSize = new Vector2(105, 105f);

        deckHand = GameObject.Find("DeckHand");
        gameObject.transform.SetParent(deckHand.transform);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = highlightedSize;
        audioManager.Play("UI Hover");
        //Debug.Log("Hover");
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
