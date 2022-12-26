using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager Instance;
    public event Action<string> ColorChange;
    public event Action PlayerPositionChange;
    public GameObject player;
    public Color playerColor;
    private void Awake()
    {
        Instance = this;
        playerColor = player.GetComponent<SpriteRenderer>().color;
    }
    public void CallColorChange(string color) => ColorChange?.Invoke(color);
    public void CallPlayerPosChange() => PlayerPositionChange?.Invoke();
}
