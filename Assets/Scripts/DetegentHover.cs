using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetegentHover : MonoBehaviour
{
    float time = 0;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string currentScene;
    private bool activated = false;
    private void sceneSwitcher()
    {
        activated = true;
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadSceneAsync("PlayerScene");
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        GManager.Instance.CallPlayerPosChange();
    }
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(new Vector2(0, 0.2f*Mathf.Sin(2.5f*time)) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated) sceneSwitcher();
    }
}
