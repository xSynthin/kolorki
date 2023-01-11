using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField] string startingScene;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] GameObject UniClip;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartColors()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(buttonClick);
        SceneManager.LoadSceneAsync("PlayerScene");
        SceneManager.LoadSceneAsync(startingScene, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
    }
}
