using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField] string startingScene;
    public void StartColors()
    {
        SoundManager.instance.playNextLevelSound();
        SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(startingScene, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("SoundScene", LoadSceneMode.Additive);
        Cursor.visible = false;
    }
}
