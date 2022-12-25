using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorMechanics : MonoBehaviour
{
    private List<string> colorList = new List<string>();
    [SerializeField] private Transform interactText;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private KeyCode reverseColorKey;
    [SerializeField] private PlayerColors availableColors;
    private Dictionary<string, Sprite> playerColorChange = new Dictionary<string, Sprite>();
    private void Awake()
    {
        playerColorChange = new Dictionary<string, Sprite>
        {
            {ColorUtility.ToHtmlStringRGB(Color.green), availableColors.green},
            {ColorUtility.ToHtmlStringRGB(Color.blue) , availableColors.blue },
            {ColorUtility.ToHtmlStringRGB(Color.red), availableColors.red},
            {ColorUtility.ToHtmlStringRGB(Color.yellow), availableColors.yellow},
            {ColorUtility.ToHtmlStringRGB(Color.white), availableColors.white},
        };
    }
    void Start()
    {
        interactText.gameObject.SetActive(false);
        colorList.Add(ColorUtility.ToHtmlStringRGB(Color.white));
        GManager.Instance.ColorChange += changeSpriteColor;
        GManager.Instance.CallColorChange(ColorUtility.ToHtmlStringRGB(Color.white));
    }

    void Update()
    {
        reverseColor();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            interactText.gameObject.SetActive(true);
            if (Input.GetKeyDown(interactKey))
            {
                if (colorList[colorList.Count -1] != ColorUtility.ToHtmlStringRGB(collision.GetComponent<SpriteRenderer>().color) && colorList.Count < 8)
                {
                    colorList.Add(ColorUtility.ToHtmlStringRGB(collision.GetComponent<SpriteRenderer>().color));
                    collision.GetComponent<ColorChanger>().SpriteColorChange();
                    PlayerUIManger.instance.AddColorSlot(colorList[colorList.Count-2]);
                    GManager.Instance.CallColorChange(ColorUtility.ToHtmlStringRGB(collision.GetComponent<SpriteRenderer>().color));
                }
            }
        }
    }
    private void changeSpriteColor(string color)
    {
        GetComponent<SpriteRenderer>().sprite = playerColorChange[color];
    }
    private void reverseColor()
    {
        if(colorList.Count - 1 > 0 && Input.GetKeyDown(reverseColorKey))
        {
            GManager.Instance.CallColorChange(colorList[colorList.Count - 2]);
            PlayerUIManger.instance.RemoveSlot(colorList[colorList.Count - 2]);
            colorList.RemoveAt(colorList.Count - 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactText.gameObject.SetActive(false);
    }
}
