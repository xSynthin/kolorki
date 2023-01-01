using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class KeyValuePair
{
    public string key;
    public Transform value;
}
public class PlayerUtils : MonoBehaviour
{
    public List<KeyValuePair> SceneSpawningPointList;
    internal int points = 0;
    [SerializeField] private Dictionary<string, Transform> SceneSpawningPointDict = new Dictionary<string, Transform>();
    public Vector3 currSceneSpawnTransform = new Vector2(0, 0);
    public Scene currentScene;
    void Start()
    {
        GManager.Instance.PlayerPositionChange += handlePlayerSpawn;
        handlePlayerSpawn();
    }
    private void Update()
    {
        ResetPosition();
    }
    private void Awake()
    {
        foreach (var kvp in SceneSpawningPointList)
        {
            SceneSpawningPointDict[kvp.key] = kvp.value;
        }
    }
    private void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.UnloadSceneAsync(currentScene.name);
            SceneManager.UnloadSceneAsync("PlayerScene");
            SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(currentScene.name, LoadSceneMode.Additive);
            transform.position = currSceneSpawnTransform;
        }
    }
    public void handlePlayerSpawn()
    {
        if(SceneSpawningPointList.Count > 0)
        {
            for(int i = 0; i < SceneManager.sceneCount; i++)
                foreach(var element in SceneSpawningPointDict)
                {
                    if(SceneManager.GetSceneAt(i) == SceneManager.GetSceneByName(element.Key))
                    {
                        transform.position = element.Value.position;
                        currSceneSpawnTransform = element.Value.position;
                        currentScene = SceneManager.GetSceneAt(i);
                    }
                }
        }
    }
}
