using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<Sprite> colorStages = new List<Sprite>();
    private Sprite currentColorSprite;
    void Start()
    {
        currentColorSprite = colorStages[colorStages.Count -1];
    }
    public void SpriteColorChange()
    {
        if(colorStages.IndexOf(currentColorSprite) - 1 >= 0)
        {
            currentColorSprite = colorStages[colorStages.IndexOf(currentColorSprite) - 1];
            GetComponent<SpriteRenderer>().sprite = currentColorSprite;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        
    }
}
