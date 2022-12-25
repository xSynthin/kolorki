using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeListener : MonoBehaviour
{
    [SerializeField] private Sprite emptyColorS;
    [SerializeField] private Sprite fullColorS;
    [SerializeField] private Color fullColorC;
    private BoxCollider2D lCollider;
    void Start()
    {
        lCollider = GetComponent<BoxCollider2D>();
        GManager.Instance.ColorChange += listenToColorChange;
    }
    void listenToColorChange(string color)
    {
        if(color == ColorUtility.ToHtmlStringRGB(fullColorC))
        {
            GetComponent<SpriteRenderer>().sprite = emptyColorS;
            lCollider.enabled = false;
        }else
        {
            GetComponent<SpriteRenderer>().sprite = fullColorS;
            lCollider.enabled = true;
        }
    }
}
