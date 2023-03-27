using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Create Card")]
public class CardObjects : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public string description;
    public Image image;
}
