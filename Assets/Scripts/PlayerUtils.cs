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
    // Start is called before the first frame update
    public List<KeyValuePair> SceneSpawningPointList;
    [SerializeField] private Dictionary<string, Transform> SceneSpawningPointDict = new Dictionary<string, Transform>();
    public Vector3 currSceneSpawnTransform = new Vector2(0, 0);
    public Scene currentScene;
    void Start()
    {
        handlePlayerSpawn();
        GManager.Instance.PlayerPositionChange += handlePlayerSpawn;
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
            SceneManager.LoadScene("PlayerScene");
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
