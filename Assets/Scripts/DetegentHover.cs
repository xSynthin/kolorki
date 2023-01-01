using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetegentHover : MonoBehaviour
{
    float time = 0;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string currentScene;
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(new Vector2(0, 0.2f*Mathf.Sin(2.5f*time)) * Time.deltaTime);
    }
    private void Start()
    {
        GManager.Instance.CallPlayerPosChange();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.Instance.fetchScoreAndColorCount(collision.GetComponent<PlayerUtils>().points, collision.GetComponent<ColorMechanics>().colorList.Count - 1);
        UIManager.Instance.fetchCurrentSceneAdnSceneToLoad(currentScene, sceneToLoad);
        UIManager.Instance.ShowEndLevelScreen();
    }
}
