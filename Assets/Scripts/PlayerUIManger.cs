using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManger : MonoBehaviour
{
    public static PlayerUIManger instance;
    [SerializeField] public GameObject colorsPanel;
    [SerializeField] GameObject colorSlot;
    private void Awake()
    {
        instance = this;
    }
    public void AddColorSlot(string color)
    {
        Color newColor;
        ColorUtility.TryParseHtmlString($"#{color}", out newColor);
        GameObject newSlot = Instantiate(colorSlot, transform.position, Quaternion.identity);
        newSlot.GetComponent<Image>().color = newColor;
        newSlot.transform.SetParent(colorsPanel.transform, false);
    }
    public void RemoveSlot(string color)
    {
        Color oldColor;
        ColorUtility.TryParseHtmlString($"#{color}", out oldColor);
        int counter = 0;
        for(int i = colorsPanel.transform.childCount-1; i >= 0; i--)
        {
            GameObject c = colorsPanel.transform.GetChild(i).gameObject;
            if (c.GetComponent<Image>().color == oldColor && counter == 0) 
            {
                counter++;
                Destroy(c);
            }
        }
    }
}
