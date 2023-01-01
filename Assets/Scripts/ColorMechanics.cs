using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorMechanics : MonoBehaviour
{
    internal List<string> colorList = new List<string>();
    [SerializeField] private Transform interactText;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private KeyCode reverseColorKey;
    [SerializeField] private PlayerColors availableColors;
    [SerializeField] private PlayerUtils playerUtils;
    private Dictionary<string, Sprite> playerColorChange = new Dictionary<string, Sprite>();
    private void Awake()
    {
        playerColorChange = new Dictionary<string, Sprite>
        {
            {ColorUtility.ToHtmlStringRGB(Color.green), availableColors.green},
            {ColorUtility.ToHtmlStringRGB(Color.blue) , availableColors.blue },
            {ColorUtility.ToHtmlStringRGB(Color.red), availableColors.red},
            {"FFFF00", availableColors.yellow},
            {ColorUtility.ToHtmlStringRGB(Color.white), availableColors.white},
            {ColorUtility.ToHtmlStringRGB(Color.magenta), availableColors.magenta},
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
                    playerUtils.points += colorList.Count -1 > 0 ? 1*(colorList.Count-1): 1;
                    colorList.Add(ColorUtility.ToHtmlStringRGB(collision.GetComponent<SpriteRenderer>().color));
                    UIManager.Instance.UpdatePoints(playerUtils.points);
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
