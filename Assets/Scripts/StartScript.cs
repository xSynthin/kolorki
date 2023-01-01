using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField] string startingScene;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartColors()
    {
        SceneManager.LoadSceneAsync("PlayerScene");
        SceneManager.LoadSceneAsync(startingScene, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
    }
}
