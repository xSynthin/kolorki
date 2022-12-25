using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetegentHover : MonoBehaviour
{
    float time = 0;
    void Start()
    {
        
    }
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(new Vector2(0, 0.2f*Mathf.Sin(2.5f*time)) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("NEXT LEVEL");
    }
}
